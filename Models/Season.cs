using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppFilm.Net.Models
{
    public class Season
    {
        public Season()
        {
            
        }
        public Season(Season season)
        {
            this.NameSSVN = season.NameSSVN;
            this.NameSS = season.NameSS;
            this.imgSS = season.imgSS;
            this.Part = season.Part;
            this.Episodes = season.Episodes;
            this.ReleaseDate = season.ReleaseDate;
        }
        public Season(string? namess, string? nameSSVN, int part,int episodes, string? imgss, DateTime releaseDate)
        {
            this.NameSS = namess;
            this.NameSSVN = nameSSVN;  
            this.Part = part;
            this.Episodes = episodes;
            this.ReleaseDate = releaseDate;
            this.imgSS = imgss;
        }
        [Key]
        public int Id { get; set; }
        public string? NameSS { get; set; }
        public string? NameSSVN { get; set; }
        public int Part { get; set; }
        public int Episodes { get; set; }
        public string? imgSS { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
    public class SeasonsConnMovie
    {
        public SeasonsConnMovie()
        {}
        public SeasonsConnMovie(int idMovie,int idSeason)
        {
            this.IdMovie = idMovie;
            this.IdSeason = idSeason;
        }
        [ForeignKey("Season")]
        public int IdSeason { get; set; }
        public Season? Season { get; set; }
        public int IdMovie { get; set; }
        public Movie? Movie { get; set; }
    }
    public class SeasonsConnPeople
    {
        public SeasonsConnPeople()
        {}
        public SeasonsConnPeople(int idPeople,int idSeason)
        {
            this.IdPeople = idPeople;
            this.IdSeason = idSeason;
        }
        [Key]
        public int Id { get; set; }
        [ForeignKey("Season")]
        public int IdSeason { get; set; }
        public Season? Season { get; set; }
        [ForeignKey("People")]
        public int IdPeople { get; set; }
        public People? People { get; set; }
    }
}