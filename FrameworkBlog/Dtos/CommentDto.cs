using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Dtos
{
    public class CommentDto
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }

    public class CommentUpdateDto
    {
        public string Text { get; set; }
    }
}
