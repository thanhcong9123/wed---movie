using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppFilm.Net.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var role = _roleManager.Roles.OrderBy(m => m.Name);
            return View(role);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if( !_roleManager.RoleExistsAsync(role.Name).GetAwaiter().GetResult())
            {
             _roleManager.CreateAsync(new IdentityRole(role.Name)).GetAwaiter().GetResult();
            }    
            return RedirectToAction("Index");
        }
    }
}