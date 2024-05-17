using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppFilm.Net.Models
{
    public class PeopleView
    {
        [Key]
        public int Id { get; set; }
        public string? NamePeople {get;set;}
        public string? Gender {get;set;}
        public string? Story {get;set;}
        public string? Image {get;set;}
        public DateTime YearofBirth { get; set; }
        public string? PlaceofBirth { get; set; }
        public string? Job {get;set;}
    
    }


    
}