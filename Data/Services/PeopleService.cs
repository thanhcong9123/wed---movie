using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFilm.Data;
using AppFilm.Net.Areas.Identity.Data;
using AppFilm.Net.Controllers;
using AppFilm.Net.Data.Base;
using AppFilm.Net.Data.Services;
using AppFilm.Net.Data.ViewModels;
using AppFilm.Net.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AppFilm.Net.Data.Repos
{
    public class PeopleService : EntityBaseRepository<People> , IPeopleService
    {

        private Dictionary<Type, object> _repositories;
        private readonly MvcMovieContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public PeopleService(MvcMovieContext context,IMapper mapper,UserManager<ApplicationUser> userManager) : base(context)
        {
            _context = context;
            _mapper =mapper;
            _repositories = new Dictionary<Type, object>();
            _userManager = userManager;
        }


        public async Task CompleteAsync()
        {
            await this._context.SaveChangesAsync();
        }
      
        public IEntityBaseRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepostory = false) where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<Type, object>();
            }
            if (hasCustomRepostory == true)
            {
                IEntityBaseRepository<TEntity> service = _context.GetService<IEntityBaseRepository<TEntity>>();
                if (service != null)
                {
                    return service;
                }
            }
            Type type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new EntityBaseRepository<TEntity>(_context);
            }
            return (IEntityBaseRepository<TEntity>)_repositories[type];
        }
        public async Task AddPeople(PeopleView people)
        {
            People inputPeople = _mapper.Map<People>(people);
                await _context.People.AddAsync(inputPeople);
                await _context.SaveChangesAsync();
                if (people.Job != null)
                {
                    PeopleConnJob peopleConnJob = new PeopleConnJob(inputPeople.Id, Int16.Parse(people.Job));
                    await _context.PeopleConnJob.AddAsync(peopleConnJob);
                    await _context.SaveChangesAsync();

                }
        }

        public async Task<People> GetPeople(int? id)
        {
            var people =await _context.People.Include(pe =>pe.PeoplePerformerConnMovies).ThenInclude(m=>m.Movie)
                                .Include(p => p.PeopleDirectorConnMovies).ThenInclude(m=>m.Movie)
                                .Include(j=>j.PeopleConnJobs).ThenInclude(j=>j.Job)
                                .FirstOrDefaultAsync(p=>p.Id == id);
            if(people != null)
            {
                return people;
            }
            return null;
        }
        public async Task<People> GetPeopleCraeteMovie(int? id)
        {
            var people =await _context.People
                                .FirstOrDefaultAsync(p=>p.Id == id);
            if(people != null)
            {
                return people;
            }
            return null;
        }
     
        
    }
}