using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppFilm.Net.Models
{
    public class Job
    {
         [Key]
        public int Id { get; set; }
        public string? NameJob {get;set;}
        public List<PeopleConnJob>? PeopleConnJobs {get;set;}
    }
 
}