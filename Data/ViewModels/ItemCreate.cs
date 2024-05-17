using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFilm.Net.Models;

namespace AppFilm.Net.Data.ViewModels
{
    public class ItemCreate
    {
        public IEnumerable<Genre>? Genres { get; set; }
            public IEnumerable<Nation>? Nations { get; set; }
            public IEnumerable<int>? PeopleDirector { get; set; }
            public IEnumerable<int>? PeoplePerformer { get; set; }
            public IEnumerable<Trailers>? Trailers { get; set; }
    }
}