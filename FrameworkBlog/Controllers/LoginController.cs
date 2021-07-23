using Blog.API.Dtos;
using Blog.API.Models;
using Blog.API.Repository;
using Blog.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController: ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(UserDto user)
        {
            var _user = await _userRepository.Login(user);

            if (_user == null)
                return NotFound();

            var token = TokenService.GenerateToken(user);

            return new
            {
                Token = token
            };
        }
    }
}
