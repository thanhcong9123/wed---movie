using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppFilm.Net.Models
{
    public class ViewDay
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Movie")]
        public int IdMovie {get;set;} 
        public Movie? Movie {get;set;}
        public int Views {get;set;}
        public ViewDay()
        {

        }
        public ViewDay (int idMovie , int view)
        {
            IdMovie = idMovie;
            Views = view;
        }
      
    }
    

  
}