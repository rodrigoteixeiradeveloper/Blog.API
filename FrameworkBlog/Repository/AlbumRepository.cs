using Blog.API.Data;
using Blog.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly IDataContext _context;

        public AlbumRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task Add(Album Album)
        {
            _context.Albums.Add(Album);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var _Album = await _context.Albums.FindAsync(id);

            // caso nao exista um usuario com o id enviado retorna uma exception
            if (_Album == null)
                throw new NullReferenceException();

            _context.Albums.Remove(_Album);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Album>> GetAll()
        {
            return await _context.Albums
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<Album> GetById(int id)
        {
            IQueryable<Album> query = _context.Albums
                .Include(p => p.User)
                .Where(p => p.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task Update(Album Album)
        {
            var _Album = await _context.Albums.FindAsync(Album.Id);

            // caso nao exista um album com o id enviado retorna uma exception
            if (_Album == null)
                throw new NullReferenceException();

            _Album.Title = Album.Title;

            await _context.SaveChangesAsync();
        }
    }
}
