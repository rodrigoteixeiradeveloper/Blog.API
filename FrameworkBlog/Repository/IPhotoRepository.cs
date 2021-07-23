using Blog.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Repository
{
    public interface IPhotoRepository
    {
        Task<Photo> GetById(int id);
        Task<IEnumerable<Photo>> GetAll();
        Task Add(Photo photo);
        Task Delete(int id);
        Task Update(Photo photo);
    }
}
