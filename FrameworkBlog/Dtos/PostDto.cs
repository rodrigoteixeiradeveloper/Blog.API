using Blog.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Dtos
{
    public class PostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}
