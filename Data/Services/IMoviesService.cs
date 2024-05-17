using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFilm.Net.Data.Base;
using AppFilm.Net.Data.ViewModels;
using AppFilm.Net.Models;
using static AppFilm.Net.Controllers.MoviesController;

namespace AppFilm.Net.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<List<Movie>> FunctionIndex(ItemFunction input);

        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task<NewMovieDropdownsItems> GetNewMovieDropdownsItem(int? id);
        Task AddNewMovie(MovieView movieView);
        Task<List<CollectionMovies>> GetConllection(string idUser);
        Task UpdateConllection(int movieId,string functionString,string userId);
        Task<GetViewMoviesHot> GetMoviesHot();
        Task<GetSeason> GetSeasonforMovie(int idMovie, int idSS);
        Task<GetSeason> DropItemForqWatch(int idMovie, int idSS, int episode);
        Task CreateSeason(CreateSeasoncl input);
        Task<NewMovieDropdownsVM> IFunctionCreate(ItemCreate listItemCreate);
        Task CreateEpisoder(ModelsCreateEpisoder inputEpisoder);
        Task<List<Season>> ListSeasonForMovie(int idMovie);
    }
}