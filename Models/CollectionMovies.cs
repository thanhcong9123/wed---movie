using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFilm.Net.Areas.Identity.Data;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;

namespace AppFilm.Net.Models
{
    public class CollectionMovies
    {
        public int IdMovie {get;set;}
        public Movie? Movie {get;set;}
        public  string? IdUser {get;set;}
        public AppFilm.Net.Areas.Identity.Data.ApplicationUser? User {get;set;}
        public CollectionMovies()
        {}
        public CollectionMovies(int movieId, string userId)
        {
            IdMovie = movieId;
            IdUser = userId;
        }
    }
}