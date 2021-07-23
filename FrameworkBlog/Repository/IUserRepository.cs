using Blog.API.Dtos;
using Blog.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Repository
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<IEnumerable<User>> GetAll();
        Task Add(User user);
        Task Delete(int id);
        Task Update(User user);
        Task<User> Login(UserDto user);
    }
}
