using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppFilm.Net.Models
{
    public class Trailers
    {
        [Key]
        public int Id { get; set; }
        public string? Img { get; set; }
        public string? Link { get; set; }
        public Trailers(string? img,string? link)
        {
            Img = img;
            Link = link;
        }
        public Trailers(Trailers trailers)
        {
            Img = trailers.Img;
            Link = trailers.Link;
        }
        public Trailers(){}
    }
    public class TrailersConnMovie
    {
        public TrailersConnMovie(TrailersConnMovie trailersConnMovie)
        {
            this.IdMovie = trailersConnMovie.IdMovie;
            this.IdTrailer = trailersConnMovie.IdTrailer;
        }
        public TrailersConnMovie(int IdMovie, int IdTrailer)
        {
            this.IdMovie = IdMovie;
            this.IdTrailer = IdTrailer;
        }
        [ForeignKey("Trailers")]
        public int IdTrailer {get;set;}
        public Trailers? Trailers {get;set;}
        public int IdMovie {get;set;}
        public Movie? Movie {get;set;}
    }   
}