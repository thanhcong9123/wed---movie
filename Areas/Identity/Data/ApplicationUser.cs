using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFilm.Net.Models;
using Microsoft.AspNetCore.Identity;

namespace AppFilm.Net.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        
       public List<CollectionMovies>? collectionMovies {get;set;}
    }
}