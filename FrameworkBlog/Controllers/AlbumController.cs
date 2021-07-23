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
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumRepository _albumRepository;
        public AlbumController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var _Album = await _albumRepository.GetById(id);

            if (_Album == null)
                return NotFound();

            return Ok(_Album);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Album>>> GetAll()
        {
            var _Albums = await _albumRepository.GetAll();

            if (_Albums == null)
                return NotFound();

            return Ok(_Albums.ToList());
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateAlbum(AlbumDto AlbumDto)
        {
            var _Album = new Album
            {
                Title = AlbumDto.Title,
                UserId = AlbumDto.UserId,
                DateCreated = DateTime.Now
            };

            await _albumRepository.Add(_Album);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteAlbum(int id)
        {
            await _albumRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateAlbum(int id, AlbumDto AlbumDto)
        {
            var _Album = new Album
            {
                Id = id,
                Title = AlbumDto.Title
            };

            await _albumRepository.Update(_Album);
            return Ok();
        }
    }
}
