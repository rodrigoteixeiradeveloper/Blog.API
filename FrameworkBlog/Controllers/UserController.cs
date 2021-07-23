using Blog.API.Dtos;
using Blog.API.Models;
using Blog.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var _user = await _userRepository.GetById(id);

            if(_user == null)
                return NotFound();

            return Ok(_user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var _users = await _userRepository.GetAll();

            if (_users == null)
                return NotFound();

            return Ok(_users);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserDto userDto)
        {
            var _user = new User
            {
                UserName = userDto.UserName,
                Password = userDto.Password,
                DateCreated = DateTime.Now
            };

            await _userRepository.Add(_user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UserDto userDto)
        {
            var _user = new User
            {
                Id = id,
                UserName = userDto.UserName,
                Password = userDto.Password
            };

            await _userRepository.Update(_user);
            return Ok();
        }
    }
}
