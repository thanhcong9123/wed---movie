using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppFilm.Net.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string? NameGenre {get;set;}
        public List<GenreConnMovie>? GenreConnMovies {get;set;}
        public Genre(int id, string? nameGenre)
        {
            Id = id;
            NameGenre = nameGenre;
        }
        public Genre()
        {
        }
    }
    public class GenreConnMovie
    {
        public GenreConnMovie()
        {
        }
        public GenreConnMovie(int idGenre, int idMovie)
        {
            IdGenre = idGenre;
            IdMovie = idMovie;
        }
        public int IdGenre {get;set;}
        public Genre? Genre {get;set;}
        public int IdMovie {get;set;}
        public Movie? Movie {get;set;}
    }   

}