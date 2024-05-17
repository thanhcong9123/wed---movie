using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppFilm.Data;
using AppFilm.Net.Models;
using AppFilm;
using System.ComponentModel.DataAnnotations;
using AppFilm.Net.Migrations;
using Microsoft.VisualBasic;
using System.Text.Json;
using AppFilm.Helpers;
using System.Runtime.Intrinsics.X86;
using Newtonsoft.Json;
using AutoMapper;
using AppFilm.Net.FileUpLoadService;
using AppFilm.Net.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using AppFilm.Net.Data.Base;
using System.Security.Claims;
using AppFilm.Net.Data.Services;

namespace AppFilm.Net.Controllers
{

    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IFileUpLoadServices _fileUpLoadServices;
        private readonly IMoviesService _service;
        public MoviesController( IFileUpLoadServices fileUpLoadServices, IMoviesService service)
        {
            _fileUpLoadServices = fileUpLoadServices;
            _service = service;
        }
        public async Task<IActionResult> MoviesHot()
        {
            // Lấy dữ liệu đã đc sắp sếp theo thứ tự số lượng like cho trang
            var moviesHot =await _service.GetMoviesHot();
            ViewBag.ViewinDay = moviesHot.ViewinDay;
            ViewBag.ViewinWeek = moviesHot.ViewinWeek;
            ViewBag.ViewinMonth = moviesHot.ViewinMonth;
            return View();
        }
        // GET: Movies
        // [HttpGet]
        public async Task<IActionResult> Home()
        {
            var movies = await this._service.GetAllAsync();
            movies = movies.OrderByDescending(m => m.Point).ToList();
            // lọc dữ liệu nations 
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
            movieDropdownsData.Nations.Insert(0, new Nation { Id = 0, NameNation = "--Tất cả--" });
            ViewBag.Nations = new SelectList(movieDropdownsData.Nations, "NameNation", "NameNation");
            // lọc dữ liệu Năm;  
            movieDropdownsData.Years.Insert(0, new Years { Id = 0, Year = "--Tất cả--" });
            movieDropdownsData.Years.Add(new Years { Id = -2014, Year = "Trước năm 2014" });
            ViewBag.Years = new SelectList(movieDropdownsData.Years, "Year", "Year");
            //Lọc dữ liệu thể loại
            movieDropdownsData.Genres.Insert(0, new Genre { Id = 0, NameGenre = "--Tất cả--" });
            ViewBag.Genres = new SelectList(movieDropdownsData.Genres, "NameGenre", "NameGenre");
            //Lọc dữ liệu Loại phim
            movieDropdownsData.MovieTypes.Insert(0, new MovieType { Id = 0, NameMovieType = "--Tất cả--" });
            ViewBag.MovieType = new SelectList(movieDropdownsData.MovieTypes, "NameMovieType", "NameMovieType");
            return View(movies);
        }
        public async Task<PartialViewResult> FunctionHome()
        {
            var movies = await (_service.GetClass().OrderByDescending(x => x.Id)).ToListAsync();
            return PartialView("GridView/_GridViewHome", movies);
        }
        public async Task<IActionResult> Index()
        {
            var movies = await this._service.GetAllAsync();
            // lọc dữ liệu nations 
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
            movieDropdownsData.Nations.Insert(0, new Nation { Id = 0, NameNation = "--Tất cả--" });
            ViewBag.Nations = new SelectList(movieDropdownsData.Nations, "NameNation", "NameNation");
            // lọc dữ liệu Năm;  
            movieDropdownsData.Years.Insert(0, new Years { Id = 0, Year = "--Tất cả--" });
            movieDropdownsData.Years.Add(new Years { Id = -2014, Year = "Trước năm 2014" });
            ViewBag.Years = new SelectList(movieDropdownsData.Years, "Year", "Year");
            //Lọc dữ liệu thể loại
            movieDropdownsData.Genres.Insert(0, new Genre { Id = 0, NameGenre = "--Tất cả--" });
            ViewBag.Genres = new SelectList(movieDropdownsData.Genres, "NameGenre", "NameGenre");
            //Lọc dữ liệu Loại phim
            movieDropdownsData.MovieTypes.Insert(0, new MovieType { Id = 0, NameMovieType = "--Tất cả--" });
            ViewBag.MovieType = new SelectList(movieDropdownsData.MovieTypes, "NameMovieType", "NameMovieType");
            return View(movies);
        }
        [HttpGet]
        public async Task<PartialViewResult> FunctionIndex(ItemFunction input)
        {
            var movies = await _service.FunctionIndex(input);
            // lọc dữ liệu nations 
            const int pageSize = 12;
            if (input.pg < 1 || input.pg == null)
            {
                input.pg = 1;
            }
            int recsCount = movies.Count();
            var pager = new PagingModel(recsCount, Convert.ToInt32(input.pg), pageSize);
            int recSkip = Convert.ToInt32((input.pg - 1) * pageSize);
            var data = movies.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            if (input.background == 2)
            {
                return PartialView("GridView/_GridViewFunction2", data);
            }
            return PartialView("GridView/_GridView", data);
        }
        public async Task<IActionResult> Search()
        {
            // Lấy ra list movies
            var movies = await this._service.GetAllAsync();
            return View(movies);
        }
        //Xử lý thông tin sau khi người dùng nhập thông tin tìm kiếm
        public async Task<PartialViewResult> FunctionSearch(string searchString)
        {
            var movies = await _service.GetAllAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.FindAll(s => s.NameEL!.Contains(searchString));
            }
            //TRả về một view để gán cho Main view
            return PartialView("GridView/_GridViewSearch", movies);
        }
        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var itemMovie = await _service.GetNewMovieDropdownsItem(id);
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var uaerNmae  = User.FindFirstValue(ClaimTypes.Name);
            if(UserId != null)
            {
                var listConllection = await _service.GetConllection(UserId);
                listConllection.ForEach(m => {
                    if(m.IdMovie == id)
                    {
                        ViewBag.CheckConllection = true;
                    }
                });
            }
            var movie = await _service.GetClass().Include(am => am.PeopleDirectorConnMovies)
                .ThenInclude(a => a.People)
                .Include(am => am.PeoplePerformerConnMovies)
                .ThenInclude(a => a.People)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }
        public async Task<IActionResult> Season(int idMovie, int idSS)
        {
            var itemMovie = await _service.GetNewMovieDropdownsItem(idMovie);
            ViewBag.Genres = itemMovie.Genres;
            ViewBag.ListTrailers = itemMovie.Trailers;
            ViewBag.ListMovieConnNation = itemMovie.Nations;
            ViewBag.PeoplesDirector = itemMovie.PeopleDirectors;
            ViewBag.PeoplesPerformer = itemMovie.PeoplePerformers;
           
            if (idMovie == 0 || idSS == 0)
            {
                return NotFound();
            }
            var season = await _service.GetSeasonforMovie(idMovie,idSS);
            if (season.linkMovies is not null)
            {
                ViewBag.Episode = season.linkMovies;
            }
            if (season == null)
            {
                return NotFound();
            }
            return View(season.seasonsConnMovie);
        }
        public async Task<IActionResult> Conllection()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // var uaerNmae  = User.FindFirstValue(ClaimTypes.Name);
            if(UserId != null)
            {
                var listConllection = await _service.GetConllection(UserId);
                return View(listConllection);
            }
            return View();
        }
        public async Task<IActionResult> UpdateConllection(int movieId,string functionString)
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(UserId != null)
            {
                await _service.UpdateConllection(movieId,functionString,UserId);
            }
            return Redirect("Details/"+movieId+"");
        }
        public async Task<IActionResult> WatchMovie(int idMovie, int idSS, int episode)
        {

            var movie =await _service.DropItemForqWatch(idMovie, idSS, episode);
            ViewBag.ListEpisodes = movie.linkMovies;
            ViewBag.WatchLink = movie.episode;
            
            // if(movie != null)
            // {
            //     var idviewDay = _service.GetRepository<ViewDay>().GetByIdAsync(idMovie);
            //     ViewDay viewDay = new ViewDay();
            //  //  await _service.GetRepository<ViewDay>().UpdateAsync(idviewDay.Id,);
            // }
            if (movie.episode == null)
            {
                return NotFound("Phim chưa được cập nhật");
            }
            
            return View(movie.seasonsConnMovie);
        }
        // GET: Movies/Create
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var item = await _service.GetNewMovieDropdownsValues();
            ViewBag.Genres = item.Genres.ToList();
            ViewBag.Nations = item.Nations.ToList();
            ViewBag.Peoples = new SelectList(item.Peoples, "Id", "NamePeople");
            ViewBag.MovieType = new SelectList(item.MovieTypes, "Id", "NameMovieType");
            return View();
        }
        [HttpPost]
        public async Task<PartialViewResult> FunctionCreate(ItemCreate listItemCreate)
        {
                var item = await _service.IFunctionCreate(listItemCreate);
                ViewBag.AllNationCrMovie = item.Nations.ToList();
                ViewBag.AllGenreCrMovie = item.Genres.ToList();
                ViewBag.PeopleDirector = item.AllDirectorConnMovie.ToList();
                ViewBag.PeoplePerformer = item.AllPerformerConnMovie.ToList();
                ViewBag.Trailers = item.Trailers.ToList();
            
            return PartialView("GridView/Create/_FunctionCreate");
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(MovieView movieView)
        {
            if (movieView != null)
            {
               await _service.AddNewMovie(movieView);
               Redirect("Index");
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public ActionResult UpLoadVideo(IFormFile formFile)
        {
            if (formFile != null)
            {
                var filePath = _fileUpLoadServices.UpLoadFile(formFile);
                return Json(formFile.FileName);
            }
            return NotFound();
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateSeason(CreateSeasoncl input)
        {
            await _service.CreateSeason(input);
            return Json("ss");
        }
      
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateEpisoder(ModelsCreateEpisoder inputEpisoder)
        {
            await _service.CreateEpisoder(inputEpisoder);
            return Json("Add Episoder ss");
        }
        // GET: Movies/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var itemMovie = await _service.GetNewMovieDropdownsItem(id);
            ViewBag.Genres = itemMovie.Genres;
            ViewBag.ListTrailers = itemMovie.Trailers;
            ViewBag.ListMovieConnNation = itemMovie.Nations;
            ViewBag.PeoplesDirector = itemMovie.PeopleDirectors;
            ViewBag.PeoplesPerformer = itemMovie.PeoplePerformers;
            var movie = await _service.GetClass().Include(mt => mt.MovieType)
                .FirstOrDefaultAsync(m => m.Id == id);
            // Lấy ss của phim
                if (movie.MovieType.NameMovieType.Equals("Phim bộ"))
                {
                    ViewBag.Season = await _service.ListSeasonForMovie(id);
                }
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }
        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameEL,NameVN,ReleaseDate,Content,Point,Image,Background")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(movie);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _service.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _service.FindAsync(id);
            if (movie != null)
            {
                await _service.DeleteAsync(movie);
            }
            return RedirectToAction(nameof(Index));
        }
        private bool MovieExists(int id)
        {
            return (_service.GetClass()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
