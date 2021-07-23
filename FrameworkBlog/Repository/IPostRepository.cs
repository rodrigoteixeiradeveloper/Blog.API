using Blog.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Repository
{
    public interface IPostRepository
    {
        Task<Post> GetById(int id);
        Task<IEnumerable<Post>> GetAll();
        Task Add(Post post);
        Task Delete(int id);
        Task Update(Post post);
    }
}
