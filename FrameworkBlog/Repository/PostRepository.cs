using Blog.API.Data;
using Blog.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly IDataContext _context;

        public PostRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task Add(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var _post = await _context.Posts.FindAsync(id);

            // caso nao exista um usuario com o id enviado retorna uma exception
            if (_post == null)
                throw new NullReferenceException();

            _context.Posts.Remove(_post);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _context.Posts
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<Post> GetById(int id)
        {
            IQueryable<Post> query = _context.Posts
                .Include(p => p.User)
                .Where(p => p.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task Update(Post post)
        {
            var _post = await _context.Posts.FindAsync(post.Id);

            // caso nao exista um post com o id enviado retorna uma exception
            if (_post == null)
                throw new NullReferenceException();

            _post.Title = post.Title;
            _post.Content = post.Content;

            await _context.SaveChangesAsync();
        }
    }
}
