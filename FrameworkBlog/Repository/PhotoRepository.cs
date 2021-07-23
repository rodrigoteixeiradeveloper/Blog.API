using Blog.API.Data;
using Blog.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Repository
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly IDataContext _context;

        public PhotoRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task Add(Photo Photo)
        {
            _context.Photos.Add(Photo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var _Photo = await _context.Photos.FindAsync(id);

            // caso nao exista uma foto com o id enviado retorna uma exception
            if (_Photo == null)
                throw new NullReferenceException();

            _context.Photos.Remove(_Photo);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Photo>> GetAll()
        {
            return await _context.Photos
                .Include(p => p.Album)
                .ThenInclude(a => a.User)
                .ToListAsync();
        }

        public async Task<Photo> GetById(int id)
        {
            IQueryable<Photo> query = _context.Photos
                .Include(p => p.Album)
                .ThenInclude(a => a.User)
                .Where(p => p.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task Update(Photo Photo)
        {
            var _Photo = await _context.Photos.FindAsync(Photo.Id);

            // caso nao exista um foto com o id enviado retorna uma exception
            if (_Photo == null)
                throw new NullReferenceException();

            _Photo.Title = Photo.Title;
            _Photo.ImageURL = Photo.ImageURL;

            await _context.SaveChangesAsync();
        }
    }
}
