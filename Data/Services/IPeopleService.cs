using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFilm.Data;
using AppFilm.Net.Data.Base;
using AppFilm.Net.Data.Services;
using AppFilm.Net.Data.ViewModels;
using AppFilm.Net.Models;

namespace AppFilm.Net.Controllers
{
    public interface IPeopleService : IEntityBaseRepository<People>
    {
     
        Task<People> GetPeople(int? id);
        Task AddPeople(PeopleView people);
        IEntityBaseRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepostory = false) where TEntity : class;
        Task CompleteAsync();
        Task<People> GetPeopleCraeteMovie(int? id);
     
    }
}