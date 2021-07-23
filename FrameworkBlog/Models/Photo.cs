using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public DateTime DateCreated { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
