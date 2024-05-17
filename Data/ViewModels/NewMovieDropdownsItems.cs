using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFilm.Net.Models;

namespace AppFilm.Net.Data.ViewModels
{
    public class NewMovieDropdownsItems
    {
        public List<NationConnMovie>? Nations {get;set;}
        public List<PeopleDirectorConnMovie>? PeopleDirectors {get;set;}
        public List<PeoplePerformerConnMovie>? PeoplePerformers {get;set;}
        public List<GenreConnMovie>? Genres {get;set;}
        public List<TrailersConnMovie>? Trailers {get;set;}
        public List<SeasonsConnMovie>? Seasons {get;set;}
    }
}