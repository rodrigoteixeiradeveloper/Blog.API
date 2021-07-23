using Blog.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Repository
{
    public interface IAlbumRepository
    {
        Task<Album> GetById(int id);
        Task<IEnumerable<Album>> GetAll();
        Task Add(Album album);
        Task Delete(int id);
        Task Update(Album album);
    }
}
