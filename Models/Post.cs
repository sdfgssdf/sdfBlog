using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vue_blog.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string Tags { get; set; }
    }
}
