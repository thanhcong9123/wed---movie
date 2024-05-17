using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppFilm.Net.Models
{
    public class People
    {
        [Key]
        public int Id { get; set; }
        public string? NamePeople {get;set;}
        public string? Gender {get;set;}
        public string? Story {get;set;}
        public string? Image {get;set;}
        public DateTime YearofBirth { get; set; }
        public string? PlaceofBirth { get; set; }
        public List<PeopleDirectorConnMovie>? PeopleDirectorConnMovies {get;set;}
        public List<PeoplePerformerConnMovie>? PeoplePerformerConnMovies {get;set;}
        public List<PeopleConnJob>? PeopleConnJobs {get;set;}
        public People(int id, string? namePeople,string? image)
        {
            Id = id;
            NamePeople = namePeople;
            Image = image;
        }
        public People(People people)
        {
            this.Id = people.Id;
            this.NamePeople = people.NamePeople;
            this.Gender = people.Gender;
            this.Story = people.Story;
            this.Image = people.Image;
            this.YearofBirth = people.YearofBirth;
            this.PlaceofBirth = people.PlaceofBirth;
        }
        public People()
        {
            
        }
    }
    public class PeopleDirectorConnMovie
    {
        public PeopleDirectorConnMovie(int idPeople, int idMovie)
        {
            IdPeople = idPeople;
            IdMovie = idMovie;
        }
        public int IdPeople {get;set;}
        public People? People {get;set;}
        public int IdMovie {get;set;}
        public Movie? Movie {get;set;}
    }  
    public class PeoplePerformerConnMovie
    {
        public PeoplePerformerConnMovie(int idPeople, int idMovie)
        {
            IdPeople = idPeople;
            IdMovie = idMovie;
        }
        public int IdPeople {get;set;}
        public People? People {get;set;}
        public int IdMovie {get;set;}
        public Movie? Movie {get;set;}
    }
    public class PeopleConnJob
    {
        public PeopleConnJob(int idPeople, int idJob)
        {
            IdPeople = idPeople;
            IdJob = idJob;
        }
        public int IdJob {get;set;}
        public Job? Job {get;set;}
        public int IdPeople {get;set;}
        public People? People {get;set;}
    }   
    
}