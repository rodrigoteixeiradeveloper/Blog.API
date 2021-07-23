using Blog.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Repository
{
    public interface ICommentRepository
    {
        Task<Comment> GetById(int id);
        Task<IEnumerable<Comment>> GetAll();
        Task Add(Comment comment);
        Task Delete(int id);
        Task Update(Comment comment);
    }
}
