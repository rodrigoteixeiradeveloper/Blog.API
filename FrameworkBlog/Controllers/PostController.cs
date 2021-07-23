using Blog.API.Dtos;
using Blog.API.Models;
using Blog.API.Repository;
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
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var _post = await _postRepository.GetById(id);

            if (_post == null)
                return NotFound();

            return Ok(_post);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Post>>> GetAll()
        {
            var _posts = await _postRepository.GetAll();

            if (_posts == null)
                return NotFound();

            return Ok(_posts.ToList());
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreatePost(PostDto postDto)
        {
            var _post = new Post
            {
                Title = postDto.Title,
                Content = postDto.Content,
                UserId = postDto.UserId,
                DateCreated = DateTime.Now
            };

            await _postRepository.Add(_post);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeletePost(int id)
        {
            await _postRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> UpdatePost(int id, PostDto PostDto)
        {
            var _Post = new Post
            {
                Id = id,
                Title = PostDto.Title,
                Content = PostDto.Content
            };

            await _postRepository.Update(_Post);
            return Ok();
        }
    }
}
