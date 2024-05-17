using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFilm.Net.Models;

namespace AppFilm.Net.Data.ViewModels
{
    public class ModelsCreateEpisoder
    {
        public int idSS { get; set; }
            public string? NameEPISODE { get; set; }
            public int Episodes { get; set; }
            public string? ImgEpisodes { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string? File { get; set; }
    }
    public class CreateSeasoncl
        {
            public Season? season { get; set; }
            public int idMovie { get; set; }
        }
}