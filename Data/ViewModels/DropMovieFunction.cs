using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFilm.Net.Data.ViewModels
{
    public class DropMovieFunction
    {
        public int Id { get; set; }
        public List<string>? NameEL { get; set; }
        public List<string>? NameMovieType { get; set; }
        public List<string>? NameGenre { get; set; }
        public List<string>? NameNation { get; set; }
        public List<string>? Content { get; set; }
        public List<DateTime>? ReleaseDate { get; set; }
        public List<float>? Point { get; set; }
        public List<string>? NameVN { get; set; }
        public List<string>? Image { get; set; }
    }
}