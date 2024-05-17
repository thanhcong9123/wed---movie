using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFilm.Net.Models;

namespace AppFilm.Net.Data.ViewModels
{
    public class NewMovieDropdownsVM
    {
        public NewMovieDropdownsVM()
        {
            Nations = new List<Nation>();
            Years = new List<Years>();
            Genres = new List<Genre>();
            MovieTypes = new List<MovieType>();
            Peoples = new List<People>();
            AllDirectorConnMovie = new List<People>();
            AllPerformerConnMovie = new List<People>();
            Trailers =  new List<Trailers>();

        }
        public List<Nation> Nations { get; set; }
        public List<Years> Years { get; set; }
        public List<Genre> Genres{ get; set; }
        public List<MovieType> MovieTypes { get; set; }
        public List<People> Peoples { get; set; }
        public List<People> AllDirectorConnMovie { get; set; }
        public List<People> AllPerformerConnMovie { get; set; } 
        public List<Trailers> Trailers { get; set; }
    }
}