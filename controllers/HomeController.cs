using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vue_blog.Data;
using vue_blog.Models;

namespace vue_blog.controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        public HomeController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public AppDbContext _ctx { get; }

        public IActionResult Index() => 
            View();
    }
}
