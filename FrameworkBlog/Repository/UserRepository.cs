using Blog.API.Data;
using Blog.API.Dtos;
using Blog.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataContext _context;

        public UserRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var _user = await _context.Users.FindAsync(id);
            
            // caso nao exista um usuario com o id enviado retorna uma exception
            if (_user == null)
                throw new NullReferenceException();

            _context.Users.Remove(_user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task Update(User user)
        {
            var _user = await _context.Users.FindAsync(user.Id);

            // caso nao exista um usuario com o id enviado retorna uma exception
            if (_user == null)
                throw new NullReferenceException();

            _user.UserName = user.UserName;
            _user.Password = user.Password;

            await _context.SaveChangesAsync();
        }

        public async Task<User> Login(UserDto user)
        {
            return await _context.Users
                .Where(
                    u => u.UserName == user.UserName
                    && u.Password == user.Password
                ).FirstOrDefaultAsync();
        }
    }
}
