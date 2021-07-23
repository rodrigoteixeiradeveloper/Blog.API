using Blog.API.Data;
using Blog.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IDataContext _context;

        public CommentRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task Add(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var _comment = await _context.Comments.FindAsync(id);

            // caso nao exista um usuario com o id enviado retorna uma exception
            if (_comment == null)
                throw new NullReferenceException();

            _context.Comments.Remove(_comment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await _context.Comments
                .Include(p => p.Post)
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<Comment> GetById(int id)
        {
            IQueryable<Comment> query = _context.Comments
                .Include(p => p.Post)
                .Include(p => p.User)
                .Where(p => p.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task Update(Comment comment)
        {
            var _comment = await _context.Comments.FindAsync(comment.Id);

            // caso nao exista um comentario com o id enviado retorna uma exception
            if (_comment == null)
                throw new NullReferenceException();

            _comment.Text = comment.Text;

            await _context.SaveChangesAsync();
        }
    }
}
