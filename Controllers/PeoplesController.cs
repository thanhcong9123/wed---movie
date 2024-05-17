using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppFilm.Data;
using AppFilm.Net.Models;
using AppFilm;
using System.ComponentModel.DataAnnotations;
using AppFilm.Net.Migrations;
using Microsoft.VisualBasic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace AppFilm.Net.Controllers
{
    [Authorize]
    public class PeoplesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPeopleService _service;

        public PeoplesController( IMapper mapper, IPeopleService service)
        {
            _mapper = mapper;
            _service = service;
        }
        //Trang xem thông tin người dùng
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }
            //Lấy người dùng khi click vào
            var people = await _service.GetPeople(id);
            if (people.PeopleConnJobs is not null)
            {
                ViewBag.JobPeople = people.PeopleConnJobs;
            }
            if (people.PeoplePerformerConnMovies is not null)
            {
                ViewBag.MoviePeople = people.PeoplePerformerConnMovies;
            }
            if (people == null)
            {
                return NotFound();
            }
            return View(people);
        }
        public async Task<ActionResult> MovieCreatePeople(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var people = await _service.GetPeople(id);
            if (people.PeopleConnJobs is not null)
            {
                ViewBag.JobPeople = people.PeopleConnJobs;
            }
            if (people.PeoplePerformerConnMovies is not null)
            {
                ViewBag.MoviePeople = people.PeoplePerformerConnMovies;
            }
            if (people == null)
            {
                return NotFound();
            }
            return Json(people);
        }
        public async Task<ActionResult> MovieCreateItemPeople(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var people = await _service.GetPeopleCraeteMovie(id);
           
            if (people == null)
            {
                return NotFound();
            }
            return Json(people);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var Job = _service.GetRepository<Job>().GetClass().ToList();
            ViewBag.Job = new SelectList(Job, "Id", "NameJob"); ;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NamePeople,Gender,Story,Image,YearofBirth,PlaceofBirth,Job")] PeopleView people)
        {
            if (people != null)
            {
                await _service.AddPeople(people);
                await _service.CompleteAsync();
                return RedirectToAction(nameof(Create));

            }
            return View();
        }

    }
}