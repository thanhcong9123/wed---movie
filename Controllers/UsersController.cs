using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AppFilm.Net.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AppFilm.Net.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
         private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _signInManager;        
        public UsersController(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> signInManager)
        {
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public class UserInList : ApplicationUser {
            // Liệt kê các Role của User ví dụ: "Admin,Editor" ...
            public string listroles {set; get;}
        }
        public async Task<IActionResult> IndexAsync()
        {
            var users  = (from u in _signInManager.Users
                          orderby u.UserName
                          select new UserInList() { 
                              Id = u.Id, UserName = u.UserName,
                          });
            List<UserInList> listUser = users.ToList();
              foreach (var user in listUser)
            {
                var roles = await _signInManager.GetRolesAsync(user);
                user.listroles = string.Join(",", roles.ToList());
            }
            return View(listUser);
        }
        public async Task<IActionResult> AddUserRole(string? id)
        {
            var user = await _signInManager.FindByIdAsync(id);
            if(user == null)
            {
                return NotFound ("Không thấy role cần xóa");
            }
            var ListRole = await _roleManager.Roles.ToListAsync();
            ViewBag.ListRoles =new SelectList(ListRole, "Id", "Name");
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> AddUserRole(string userName, string id)
        {
            var users = await _signInManager.FindByIdAsync(userName);
            if(users == null)
            {
                return NotFound ("Không thấy role cần xóa");
            }
            var roles = await _signInManager.GetRolesAsync(users);
            var role =  await _roleManager.FindByIdAsync(id);
            await _signInManager.AddToRoleAsync(users,role.Name);
            foreach (var rolename in roles)
            {
            if (role.Name.Contains(rolename)) continue;
            await _signInManager.RemoveFromRoleAsync(users, rolename);
            }
            return RedirectToAction("Index");
        }
        
    }
}