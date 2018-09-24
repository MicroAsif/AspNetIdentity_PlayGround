using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetIdentity_PlayGround.Data;
using AspNetIdentity_PlayGround.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetIdentity_PlayGround.Models
{
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<UserModel> userManager;
        private readonly RoleManager<RoleModel> roleManager;
        private readonly SignInManager<UserModel> signInManager;

      

        public UserController(ApplicationDbContext context, UserManager<UserModel> userManager,
            RoleManager<RoleModel> roleManager, SignInManager<UserModel> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }


        // GET: /<controller>/
        public async  Task<IActionResult> Index()
        {
            List<UserList> userList = new List<UserList>();
            
            var users = userManager.Users.ToList();

            foreach (var user in users)
            {
                string rolesName = "";
                var userRoles = await userManager.GetRolesAsync(user);
                foreach (var userRole in userRoles)
                {
                    rolesName += userRole;
                }
                userList.Add(new UserList { FullName = user.FullName, Email = user.Email, Roles = rolesName });
            }
            return View(userList);
        }

        public async Task<IActionResult> CreateRole()
        {
            string role = "Manager";
            
            if (!roleManager.Roles.Any(x=>x.Name == "Manager"))
            {
                await roleManager.CreateAsync(new RoleModel { Name = "Manager" });
                return RedirectToAction("index", "home");
            }
                
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateUser()
        {
            if (userManager.Users.Count()>0)
            {
                var newUser = new UserModel { FullName = "moshiur rahman", Email = "moshiur@live.com", UserName = "moshiur@live.com" };
               
                var userResult = await userManager.CreateAsync(newUser);
                if (userResult.Succeeded)
                {
                   await userManager.AddPasswordAsync(newUser, "Abc123@#");
                   await userManager.AddToRoleAsync(newUser, "Manager");
                }
                return RedirectToAction("index", "home");
            }
            return RedirectToAction("index");
        }

        public async Task<ActionResult> ChangePassword()
        {
            string oldPass = "Abc123@#";
            string newPass = "Abc123@#";
            var user = await userManager.GetUserAsync(User);
            var changePasswordResult = await userManager.ChangePasswordAsync(user, oldPass, newPass);
            if (!changePasswordResult.Succeeded)
            {
                ///user.id
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                ViewBag.StatusMessage = "Something wrong.";
                return View();
            }

            await signInManager.RefreshSignInAsync(user);
            ViewBag.StatusMessage = "Your password has been changed.";
            return View();
        }

        public async Task<IActionResult> Logout(string returnUrl)
        {
            await signInManager.SignOutAsync();
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            return RedirectToAction("index", "home");
        }
    }
}
