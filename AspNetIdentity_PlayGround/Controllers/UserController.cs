using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetIdentity_PlayGround.Data;
using AspNetIdentity_PlayGround.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetIdentity_PlayGround.Models
{
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<UserModel> userManager;
        private readonly RoleManager<RoleModel> roleManager;

        public UserController(ApplicationDbContext context, UserManager<UserModel> userManager,
            RoleManager<RoleModel> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateRole()
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new RoleModel { Name = "Admin" });
                return RedirectToAction("index", "home");
            }
                
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateUser()
        {
            if (!userManager.Users.Any())
            {
                var newUser = new UserModel { FullName = "asif rahman", Email = "asif0531@live.com", UserName = "microasif" };
               
                var userResult = await userManager.CreateAsync(newUser);
                if (userResult.Succeeded)
                {
                   await userManager.AddPasswordAsync(newUser, "Abc123@#");
                   await userManager.AddToRoleAsync(newUser, "Admin");
                }
                return RedirectToAction("index", "home");
            }
            return RedirectToAction("index");
        }
    }
}
