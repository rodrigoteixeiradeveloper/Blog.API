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
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var _Comment = await _commentRepository.GetById(id);

            if (_Comment == null)
                return NotFound();

            return Ok(_Comment);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Comment>>> GetAll()
        {
            var _Comments = await _commentRepository.GetAll();

            if (_Comments == null)
                return NotFound();

            return Ok(_Comments.ToList());
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateComment(CommentDto CommentDto)
        {
            var _Comment = new Comment
            {
                Text = CommentDto.Text,
                UserId = CommentDto.UserId,
                PostId = CommentDto.PostId,
                DateCreated = DateTime.Now
            };

            await _commentRepository.Add(_Comment);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteComment(int id)
        {
            await _commentRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateComment(int id, CommentUpdateDto CommentDto)
        {
            var _Comment = new Comment
            {
                Id = id,
                Text = CommentDto.Text
            };

            await _commentRepository.Update(_Comment);
            return Ok();
        }
    }
}
