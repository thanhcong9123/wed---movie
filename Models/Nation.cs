using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppFilm.Net.Models
{
    public class Nation
    {
        [Key]
        public int Id { get; set; }
        public string? NameNation {get;set;}
        public List<NationConnMovie>? NationConnMovies {get;set;}
        public Nation(int id, string? nameNation)
        {
            Id = id;
            NameNation = nameNation;
        }
        public Nation( string? nameNation)
        {
            
            NameNation = nameNation;
        }
         public Nation()
        {
        }
    }
    public class NationConnMovie
    {

        public NationConnMovie()
        {
        }
        public NationConnMovie(int idnation,int idMovie)
        {
            IdNation = idnation;
            IdMovie = idMovie;
        }
        public int IdNation {get;set;}
        public Nation? Nation {get;set;}
        public int IdMovie {get;set;}
        public Movie? Movie {get;set;}
    }   
}