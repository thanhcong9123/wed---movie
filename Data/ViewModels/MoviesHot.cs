using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFilm.Net.Data.ViewModels
{
    public class MoviesHot
    {
        public int Id {get;set;}
        public string? NameEL {get;set;}
        public string? Background {get;set;}
        public string? Image {get;set;}
        public float? Point {get;set;}
        public string? Content {get;set;}
        public DateTime ReleaseDate { get; set; }
        public int View {get;set;}

    }
}