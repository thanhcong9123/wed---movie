using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFilm.Data;
using AppFilm.Net.Areas.Identity.Data;
using AppFilm.Net.Data.Base;
using AppFilm.Net.Data.ViewModels;
using AppFilm.Net.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static AppFilm.Net.Controllers.MoviesController;

namespace AppFilm.Net.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {

        private readonly MvcMovieContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public MoviesService(MvcMovieContext context,IMapper mapper,UserManager<ApplicationUser> userManager): base(context)
        {
            _context = context;
            _mapper =mapper;
      
            _userManager = userManager;
        }
        public async Task<List<Movie>> FunctionIndex(ItemFunction input)
        {

            var movie = await _context.Movie.Include(am => am.PeopleDirectorConnMovies)
                .ThenInclude(a => a.People)
                .Include(am => am.PeoplePerformerConnMovies)
                .ThenInclude(a => a.People).Include(am => am.Years).Include(am => am.MovieType)
                .Include(am => am.NationConnMovies)
                .ThenInclude(a => a.Nation)
                .Include(am => am.GenreConnMovies)
                .ThenInclude(a => a.Genre)
                .Include(am => am.SeasonsConnMovies)
                .ThenInclude(a => a.Season)
                .Include(am => am.TrailersConnMovies)
                .ThenInclude(a => a.Trailers).ToListAsync();
            // lọc dữ liệu Năm;   
            if (input.yearTostring == "Trước năm 2014" && input.yearTostring != null)
            {
                movie = movie.Where(g=>g.ReleaseDate.Year < 2014).ToList();
            }
            // Lọc dữ liệu theo năm được truyền từ các trang ngoài Index
            if (input.yearTostring != "--Tất cả--" && input.yearTostring != null && input.yearTostring != "Trước năm 2014")
            {
                movie = movie.Where(g=>g.ReleaseDate.Year == Int32.Parse(input.yearTostring)).ToList();
            }
            // //Lọc dữ liệu theo thể được truyền từ các trang ngoài Index
            if (input.theLoaiTostring != "--Tất cả--" && input.theLoaiTostring != null)
            {
                movie = movie.Where(m=>m.GenreConnMovies.Any(g=> g.Genre.NameGenre== input.theLoaiTostring)).ToList();
            }
            // //Lọc dữ liệu theo thể được truyền từ các trang ngoài Index
            if (input.nationPostTostring != "--Tất cả--" && input.nationPostTostring != null)
            {
                movie = movie.Where(m=>m.NationConnMovies.Any(g=> g.Nation.NameNation== input.nationPostTostring)).ToList();
            }
            // //Lọc dữ liệu theo thể được truyền từ các trang ngoài Index
            if (input.movietypeTostring != "--Tất cả--" && input.movietypeTostring != null)
            {
                movie = movie.Where(m=>m.MovieType.NameMovieType == input.movietypeTostring).ToList();
            }            
            return movie;
        }
   

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Nations = await _context.Nation.ToListAsync(),
                Years = await _context.Years.ToListAsync(),
                Genres = await _context.Genre.ToListAsync(),
                MovieTypes = await _context.MovieType.ToListAsync(),
                Peoples = await _context.People.ToListAsync()
            };
            return response;
        }
        public async Task<NewMovieDropdownsItems> GetNewMovieDropdownsItem(int? id)
        {
            var response = new NewMovieDropdownsItems()
            {
                Nations = await _context.NationConnMovie.Include(n => n.Nation).Include(m => m.Movie).Where(m => m.IdMovie == id).ToListAsync(),
                Genres = await _context.GenreConnMovie.Include(g => g.Genre).Include(m => m.Movie).Where(m => m.IdMovie == id).ToListAsync(),
                PeopleDirectors =await _context.PeopleDirectorConnMovies.Include(p=>p.People).Include(s=>s.Movie).Where(m => m.IdMovie == id).ToListAsync(),
                PeoplePerformers =await _context.PeoplePerformerConnMovies.Include(p=>p.People).Include(s=>s.Movie).Where(m => m.IdMovie == id).ToListAsync(),
                Trailers = await _context.TrailersConnMovie.Include(t => t.Trailers).Include(m => m.Movie).Where(m => m.IdMovie == id).ToListAsync(),
                Seasons = await _context.SeasonsConnMovie.Include(s => s.Season).Include(m => m.Movie).Where(m => m.IdMovie == id).ToListAsync()

            };
            return response;
        }

        public async Task AddNewMovie(MovieView movieView)
        {
            if (movieView != null)
            {
                var IdYear = _context.Years.FirstOrDefault(y => y.Year.Equals(movieView.ReleaseDate.Year.ToString()));
                if(IdYear != null)
                {
                    movieView.IdYears = IdYear.Id;
                }
                //add Phim vaof csdl
                Movie movie = _mapper.Map<Movie>(movieView);
                await _context.Movie.AddAsync(movie);
                await _context.SaveChangesAsync();
                //Lưu season cua phim hiện tại
                Season season = new Season();
                if (movieView.Episodes != 0)
                {
                    Season season2 = new Season(movie.NameEL, movie.NameVN, 1, movieView.Episodes, movie.Image, movie.ReleaseDate);
                    season = season2;
                    await _context.Season.AddAsync(season);
                    await _context.SaveChangesAsync();
                    SeasonsConnMovie seasonsConnMovie = new SeasonsConnMovie(movie.Id, season.Id);
                    await _context.SeasonsConnMovie.AddAsync(seasonsConnMovie);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Season season2 = new Season(movie.NameEL, movie.NameVN, 1, 1, movie.Image, movie.ReleaseDate);
                    season = season2;
                    await _context.Season.AddAsync(season);
                    await _context.SaveChangesAsync();
                    SeasonsConnMovie seasonsConnMovie = new SeasonsConnMovie(movie.Id, season.Id);
                    await _context.SeasonsConnMovie.AddAsync(seasonsConnMovie);
                    await _context.SaveChangesAsync();
                }
                //Lưu file video của bộ phim
                if (movieView.FileName != null)
                {
                    LinkMovie linkMovie = new LinkMovie(movieView.NameEL, 1, movie.Image, movie.ReleaseDate, "~/VideoFile\\" + movieView.FileName);
                    await _context.LinkMovie.AddAsync(linkMovie);
                    await _context.SaveChangesAsync();
                    SeasonsConnLinkMovie seasonsConnLinkMovie = new SeasonsConnLinkMovie(season.Id, linkMovie.Id);
                    await _context.SeasonsConnLinkMovie.AddAsync(seasonsConnLinkMovie);
                    await _context.SaveChangesAsync();
                }
                //Liên kết trailer với phim vừa khởi tạo
                if (movieView.Trailers != null)
                {
                    foreach (var item in movieView.Trailers)
                    {
                        Trailers trailer = new Trailers(item);
                        await _context.Trailers.AddAsync(trailer);
                        await _context.SaveChangesAsync();
                        TrailersConnMovie trailersConnMovie = new TrailersConnMovie(movie.Id, trailer.Id);
                        await _context.TrailersConnMovie.AddAsync(trailersConnMovie);
                        await _context.SaveChangesAsync();
                    }
                }
                //Thể loại của bộ phim
                if (movieView.Genres != null)
                {
                    foreach (var item in movieView.Genres)
                    {
                        
                        GenreConnMovie genreConnMovie = new GenreConnMovie(item.Id, movie.Id);
                        await _context.GenreConnMovie.AddAsync(genreConnMovie);
                        await _context.SaveChangesAsync();
                    }
                }
                //Các quốc gia tham gia phim
                if (movieView.Nation != null)
                {
                    foreach (var item in movieView.Nation)
                    {
                        NationConnMovie nationConnMovie = new NationConnMovie(item.Id, movie.Id);
                        await _context.NationConnMovie.AddAsync(nationConnMovie);
                        await _context.SaveChangesAsync();
                    }
                }
                //Diễn viên của bộ phim
                if (movieView.PeoplePerformer != null)
                {
                    foreach (var item in movieView.PeoplePerformer)
                    {
                        PeoplePerformerConnMovie people = new PeoplePerformerConnMovie(item, movie.Id);
                        await _context.PeoplePerformerConnMovies.AddAsync(people);
                        await _context.SaveChangesAsync();
                        SeasonsConnPeople seasonsConnPeople = new SeasonsConnPeople(item, season.Id);
                        await _context.SeasonsConnPeople.AddAsync(seasonsConnPeople);
                        await _context.SaveChangesAsync();
                    }
                }
                //đạo diễn của phim
                if (movieView.PeopleDirector != null)
                {
                    foreach (var item in movieView.PeopleDirector)
                    {
                        PeopleDirectorConnMovie people = new PeopleDirectorConnMovie(item, movie.Id);
                        await _context.PeopleDirectorConnMovies.AddAsync(people);
                        await _context.SaveChangesAsync();
                    }
                }
                //Add him vào table view
                ViewDay viewDay = new ViewDay(movie.Id,0);
                ViewMonth viewMonth = new ViewMonth(movie.Id,0);
                ViewWeek viewWeek = new ViewWeek(movie.Id,0);
                await _context.ViewDay.AddAsync(viewDay);
                await _context.ViewWeek.AddAsync(viewWeek);
                await _context.ViewMonth.AddAsync(viewMonth);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<CollectionMovies>> GetConllection(string idUser)
        {
            var user = await _userManager.FindByIdAsync(idUser);
            var conllection = await _context.CollectionMovies.Include(m =>m.Movie).Where(u =>u .IdUser == idUser).ToListAsync();
            return conllection;
        }
        public async Task UpdateConllection(int movieId,string functionString,string userId)
        {
            if(functionString.Equals("Add"))
            {
                CollectionMovies collectionMovies = new CollectionMovies(movieId,userId);
                await _context.CollectionMovies.AddAsync(collectionMovies);
                await _context.SaveChangesAsync();
            }
            else
            {
               
                var collectionMovies = await _context.CollectionMovies.Include(u =>u.Movie).FirstOrDefaultAsync(u=>u.IdUser == userId && u.IdMovie == movieId);
                if(collectionMovies != null)
                {
                    _context.CollectionMovies.Remove(collectionMovies);
                    await _context.SaveChangesAsync();
                }
                
            }
        }

        public async Task<GetViewMoviesHot> GetMoviesHot()
        {
            var viewinDay = await ((from m in _context.Movie
                                    join d in _context.ViewDay
                                    on m.Id equals d.IdMovie
                                    where m.Id == d.IdMovie
                                    select new MoviesHot
                                    {
                                        Id = m.Id,
                                        NameEL = m.NameEL,
                                        Background = m.Background,
                                        Image = m.Image,
                                        Point = m.Point,
                                        Content = m.Content,
                                        ReleaseDate = m.ReleaseDate,
                                        View = d.Views
                                    }).OrderByDescending(s => s.View)).ToListAsync();
            // sắp xếp theo lượng view trong ngày
            var viewinWeek = await ((from m in _context.Movie
                                     join d in _context.ViewWeek
                                     on m.Id equals d.IdMovie
                                     where m.Id == d.IdMovie
                                     select new MoviesHot
                                     {
                                         Id = m.Id,
                                         NameEL = m.NameEL,
                                         Background = m.Background,
                                         Image = m.Image,
                                         Point = m.Point,
                                         Content = m.Content,
                                         ReleaseDate = m.ReleaseDate,
                                         View = d.Views
                                     }).OrderByDescending(s => s.View)).ToListAsync();
            // sắp xếp theo lượng view trong tháng
            var viewinMonth = await ((from m in _context.Movie
                                      join d in _context.ViewMonth
                                      on m.Id equals d.IdMovie
                                      where m.Id == d.IdMovie
                                      select new MoviesHot
                                      {
                                          Id = m.Id,
                                          NameEL = m.NameEL,
                                          Background = m.Background,
                                          Image = m.Image,
                                          Point = m.Point,
                                          Content = m.Content,
                                          ReleaseDate = m.ReleaseDate,
                                          View = d.Views
                                      }).OrderByDescending(s => s.View)).ToListAsync();
            GetViewMoviesHot moviesHot = new GetViewMoviesHot
            {
                ViewinDay = viewinDay,
                ViewinMonth = viewinMonth,
                ViewinWeek = viewinWeek
            };
            return moviesHot;
        }
        public async Task<GetSeason> GetSeasonforMovie(int idMovie, int idSS)
        {
            var season = await _context.SeasonsConnMovie.Include(s => s.Season).Include(s => s.Movie).FirstOrDefaultAsync(t => t.IdMovie == idMovie && t.IdSeason == idSS);
            var episode = await(from s in _context.SeasonsConnMovie
                          join ss in _context.Season
                          on s.IdSeason equals ss.Id
                          join epi in _context.SeasonsConnLinkMovie
                          on ss.Id equals epi.IdSeason
                          join link in _context.LinkMovie
                          on epi.IdLinkMovie equals link.Id
                          where s.IdMovie == idMovie && ss.Id == idSS
                          select link).ToListAsync();
            GetSeason getSeason = new GetSeason()
            {
                seasonsConnMovie = season,
                linkMovies = episode
            };
            return getSeason;
        }
        public async Task<GetSeason> DropItemForqWatch(int idMovie, int idSS, int episode)
        {
            GetSeason getSeason = new GetSeason();
            getSeason.seasonsConnMovie = await _context.SeasonsConnMovie.Include(m => m.Movie).Include(m => m.Season).FirstOrDefaultAsync(m => m.IdMovie == idMovie);
            if (episode != 0 && idSS != 0 && idMovie != 0)
            {
                var watchseason = await _context.LinkMovie.FirstOrDefaultAsync(a=>a.Id == episode);
                var listEpisodes = from a in _context.SeasonsConnLinkMovie
                                   join b in _context.LinkMovie
                                   on a.IdLinkMovie equals b.Id
                                   where a.IdSeason == idSS
                                   select b;
                listEpisodes = listEpisodes.OrderBy(m => m.Episodes);
                if(watchseason != null)
                {
                    getSeason.linkMovies =await listEpisodes.ToListAsync();
                    getSeason.episode = watchseason;
                }
                
            }
            else if (idMovie != 0 && idSS == 0)
            {
                getSeason.seasonsConnMovie = await _context.SeasonsConnMovie.Include(m => m.Movie).Include(m => m.Season).FirstOrDefaultAsync(m => m.IdMovie == idMovie && m.Season.Part == 1);
                var findseason = from a in _context.Movie
                                 join b in _context.SeasonsConnMovie
                                 on a.Id equals b.IdMovie
                                 join c in _context.Season
                                 on b.IdSeason equals c.Id
                                 where c.Part == 1 && a.Id == idMovie
                                 select c;
                var watchseason = from a in findseason
                                  join lccon in _context.SeasonsConnLinkMovie
                                  on a.Id equals lccon.IdSeason
                                  join li in _context.LinkMovie
                                  on lccon.IdLinkMovie equals li.Id
                                  where li.Episodes == 1
                                  select new LinkMovie
                                  {
                                    Id = li.Id,
                                    NameEPISODE =li.NameEPISODE,
                                    Episodes = li.Episodes,
                                    ImgEpisodes = li.ImgEpisodes,
                                    ReleaseDate = li.ReleaseDate,
                                    File = li.File
                                  };
                var listEpisodes = from a in findseason
                                   join lccon in _context.SeasonsConnLinkMovie
                                   on a.Id equals lccon.IdSeason
                                   join li in _context.LinkMovie
                                   on lccon.IdLinkMovie equals li.Id
                                   select li;
                listEpisodes = listEpisodes.OrderBy(m => m.Episodes);
                if(watchseason.Count() > 0)
                {
                    getSeason.linkMovies =await listEpisodes.ToListAsync();
                    getSeason.episode =await watchseason.FirstAsync();
                }
            }
            else if (idMovie != 0 && idSS != 0)
            {
                getSeason.seasonsConnMovie = await _context.SeasonsConnMovie.Include(m => m.Movie).Include(m => m.Season).FirstOrDefaultAsync(m => m.IdMovie == idMovie && m.IdSeason == idSS);
                var watchseason = from a in _context.SeasonsConnLinkMovie
                                  join b in _context.LinkMovie
                                  on a.IdLinkMovie equals b.Id
                                  where a.IdSeason == idSS && b.Episodes == 1
                                  select b;
                var listEpisodes = from a in _context.SeasonsConnLinkMovie
                                   join b in _context.LinkMovie
                                   on a.IdLinkMovie equals b.Id
                                   where a.IdSeason == idSS
                                   select b;
                listEpisodes = listEpisodes.OrderBy(m => m.Episodes);
                if(watchseason.Count() > 0)
                {
                    getSeason.linkMovies =await listEpisodes.ToListAsync();
                    getSeason.episode =await watchseason.FirstAsync();
                }
            }
            if(getSeason.episode != null && idMovie != 0)
            {
                var viewDay = await _context.ViewDay.FirstOrDefaultAsync(m=>m.IdMovie == idMovie);
                if(viewDay != null)
                {
                    viewDay.Views = viewDay.Views + 1;
                    _context.ViewDay.UpdateRange(viewDay);
                    await _context.SaveChangesAsync();
                }
                var viewT = await _context.ViewMonth.FirstOrDefaultAsync(m=>m.IdMovie == idMovie);
                if(viewT != null)
                {
                    viewT.Views = viewT.Views + 1;
                    _context.ViewMonth.UpdateRange(viewT);
                    await _context.SaveChangesAsync();
                }
                var viewW = await _context.ViewWeek.FirstOrDefaultAsync(m=>m.IdMovie == idMovie);
                if(viewW != null)
                {
                    viewW.Views = viewW.Views + 1;
                    _context.ViewWeek.UpdateRange(viewW);
                    await _context.SaveChangesAsync();
                }
                
            }
           return getSeason;
        }
        public async Task CreateSeason(CreateSeasoncl input)
        {
            if (input.season != null || input.idMovie != 0)
            {
                var season = new Season(input.season);
                if (season != null)
                {
                    await _context.Season.AddAsync(season);
                    await _context.SaveChangesAsync();
                    var seasonsConnMovie = new SeasonsConnMovie(input.idMovie, season.Id);
                    await _context.SeasonsConnMovie.AddAsync(seasonsConnMovie);
                    await _context.SaveChangesAsync();
                }
            }
        }
        public async Task<NewMovieDropdownsVM> IFunctionCreate(ItemCreate listItemCreate)
        {
            var response = new NewMovieDropdownsVM();
            if (listItemCreate.Nations != null)
            {
                foreach (var item in listItemCreate.Nations)
                {
                    response.Nations.Add(new Nation(item.Id, item.NameNation));
                }
            }
            if (listItemCreate.Genres != null)
            {
                foreach (var item in listItemCreate.Genres)
                {
                    response.Genres.Add(new Genre(item.Id, item.NameGenre));
                }
            }
            if (listItemCreate.PeopleDirector != null)
            {
                foreach (var item in listItemCreate.PeopleDirector)
                {
                    var Director = await _context.People.FindAsync(item);
                    var checkDirector = response.AllDirectorConnMovie.FirstOrDefault(m => m.Id == item);
                    if (Director != null && checkDirector == null)
                    {
                        response.AllDirectorConnMovie.Add(new People(Director));
                    }
                }
            }
            if (listItemCreate.PeoplePerformer != null)
            {
                foreach (var item in listItemCreate.PeoplePerformer)
                {
                    var Performer = await _context.People.FindAsync(item);
                    var checkPerformer = response.AllPerformerConnMovie.FirstOrDefault(m => m.Id == item);
                    if (Performer != null && checkPerformer == null)
                    {
                        response.AllPerformerConnMovie.Add(new People(Performer));
                    }
                }
            }
            if (listItemCreate.Trailers != null)
            {
                foreach (var item in listItemCreate.Trailers)
                {
                    if (item.Link != null)
                    {
                        var checkTrailer = response.Trailers.FirstOrDefault(m => m.Link == item.Link);
                        if (checkTrailer == null)
                        {
                            response.Trailers.Add(new Trailers(item));
                        }
                    }
                }
               
            }
            return response;
        }
        public async Task CreateEpisoder(ModelsCreateEpisoder inputEpisoder)
        {
            if (inputEpisoder != null && inputEpisoder.idSS != 0)
            {
                LinkMovie linkMovie = new LinkMovie(inputEpisoder.NameEPISODE, inputEpisoder.Episodes, inputEpisoder.ImgEpisodes, inputEpisoder.ReleaseDate, "~/VideoFile\\" + inputEpisoder.File);
                if (linkMovie != null)
                {
                    await _context.LinkMovie.AddAsync(linkMovie);
                    await _context.SaveChangesAsync();
                    SeasonsConnLinkMovie seasonsConnLinkMovie = new SeasonsConnLinkMovie(inputEpisoder.idSS, linkMovie.Id);
                    await _context.SeasonsConnLinkMovie.AddAsync(seasonsConnLinkMovie);
                    await _context.SaveChangesAsync();
                }
            }
        }
        public async Task<List<Season>> ListSeasonForMovie(int idMovie)
        {
            var Season = (from m in _context.Movie
                                      join Ssc in _context.SeasonsConnMovie
                                      on m.Id equals Ssc.IdMovie
                                      join Ss in _context.Season
                                      on Ssc.IdSeason equals Ss.Id
                                      where Ssc.IdMovie == idMovie
                                      select Ss).ToList();
                                      return Season;
        }

    }

}