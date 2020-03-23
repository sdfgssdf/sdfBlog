using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vue_blog.Data;
using vue_blog.Models;

namespace vue_blog.controllers
{
    [Authorize]
    [Route("[Controller]/[Action]")]
    public class BlogAdminController : Controller
    {
        public BlogAdminController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public AppDbContext _ctx { get; }

        public IActionResult Index() => View(_ctx.Posts);
        [HttpPost]
        public async Task<IActionResult>  Index (string title, string body, string tags){
            _ctx.Posts.Add(new Post { Body = body, Title = title ,Tags = tags});
            await _ctx.SaveChangesAsync();

            //       return redirecttoaction("index" , "blogadmin");
            return View(_ctx.Posts);
        }
        [HttpDelete]
        public async Task<IActionResult> Index(Guid id)
        {

           var post = await _ctx.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            await _ctx.SaveChangesAsync();
            _ctx.Posts.Remove(post);
            return NoContent();
        }
    }
}