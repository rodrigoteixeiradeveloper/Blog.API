using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Dtos
{
    public class PhotoDto
    {
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public int AlbumId { get; set; }
    }
}
