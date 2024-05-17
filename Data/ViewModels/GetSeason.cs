using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFilm.Net.Models;

namespace AppFilm.Net.Data.ViewModels
{
    public class GetSeason
    {
        public SeasonsConnMovie? seasonsConnMovie {get;set;}
        public List<LinkMovie>? linkMovies {get;set;}
        public LinkMovie? episode {get;set;}
    }
}