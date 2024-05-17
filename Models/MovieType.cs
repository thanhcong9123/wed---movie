using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppFilm.Net.Models
{
    public class MovieType
    {
        [Key]
        public int Id { get; set; }
        public string? NameMovieType {get;set;}
    }
     
}