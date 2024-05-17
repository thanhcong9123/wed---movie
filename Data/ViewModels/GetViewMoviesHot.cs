using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFilm.Net.Data.ViewModels
{
    public class GetViewMoviesHot
    {
        public List<MoviesHot>? ViewinDay {get;set;}
        public List<MoviesHot>? ViewinWeek {get;set;}
        public List<MoviesHot>? ViewinMonth {get;set;}
    }
}