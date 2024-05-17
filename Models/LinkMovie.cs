using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppFilm.Net.Models
{
    public class LinkMovie
    {
        public LinkMovie()
        {

        }
        public LinkMovie(string? nameEPISODE, int episodes, string? imgEpisodes, DateTime releaseDate, string? file)
        {
            this.NameEPISODE = nameEPISODE;
            this.Episodes = episodes;
            this.ImgEpisodes = imgEpisodes;
            this.ReleaseDate = releaseDate;
            this.File = file;
        }
        [Key]
        public int Id { get; set; }
        public string? NameEPISODE { get; set; }
        public int Episodes {get; set; }
        public string? ImgEpisodes {get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? File { get; set; }
    }
    public class SeasonsConnLinkMovie
    {
        public SeasonsConnLinkMovie()
        {
        }
        public SeasonsConnLinkMovie(int idSS, int idLink)
        {
            this.IdSeason = idSS;
            this.IdLinkMovie = idLink;
        }
        [Key]
        public int Id {get;set;}
        [ForeignKey("Season")]
        public int IdSeason {get;set;}
        public Season? Season {get;set;}
        [ForeignKey("LinkMovie")]
        public int IdLinkMovie {get;set;}
        public LinkMovie? LinkMovie {get;set;}
    }  
}