using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vue_blog.Data;
using vue_blog.Models;

namespace vue_blog.controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BlogController : Controller
    {
        public BlogController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public AppDbContext _ctx { get; }

        public IEnumerable<Post> GetPosts() => _ctx.Posts.ToList();
        [HttpGet("id/{id}")]
        public Post GetPost(Guid id) => _ctx.Posts.First(x => x.Id ==id);
        [HttpGet("{title}")]
        public Post GetPostByTitle(string title) => _ctx.Posts.First(x => x.Title == title);
        
    }
}
