using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vue_blog.Data;
using vue_blog.Models;

namespace vue_blog.controllers
{
    [Route("[Controller]/[Action]")]
    public class AccountController : Controller
    {
        public AccountController(AppDbContext ctx, SignInManager<IdentityUser> signInManager)
        {
            _ctx = ctx;
            _signInManager = signInManager;
        }

        public AppDbContext _ctx { get; }
        public SignInManager<IdentityUser> _signInManager { get; }

        public IActionResult Login() => View();
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password){
        var result =    await _signInManager.PasswordSignInAsync(username,password,false,false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "BlogAdmin");
            }
            return RedirectToAction("Index", "Account");
        }
    }
}