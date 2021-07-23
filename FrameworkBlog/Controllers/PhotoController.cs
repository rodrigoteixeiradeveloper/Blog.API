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
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoRepository _photoRepository;
        public PhotoController(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Photo>> GetPhoto(int id)
        {
            var _Photo = await _photoRepository.GetById(id);

            if (_Photo == null)
                return NotFound();

            return Ok(_Photo);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Photo>>> GetAll()
        {
            var _Photos = await _photoRepository.GetAll();

            if (_Photos == null)
                return NotFound();

            return Ok(_Photos.ToList());
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreatePhoto(PhotoDto PhotoDto)
        {
            var _Photo = new Photo
            {
                Title = PhotoDto.Title,
                ImageURL = PhotoDto.ImageURL,
                AlbumId = PhotoDto.AlbumId,
                DateCreated = DateTime.Now
            };

            await _photoRepository.Add(_Photo);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeletePhoto(int id)
        {
            await _photoRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> UpdatePhoto(int id, PhotoDto PhotoDto)
        {
            var _Photo = new Photo
            {
                Id = id,
                Title = PhotoDto.Title,
                ImageURL = PhotoDto.ImageURL
            };

            await _photoRepository.Update(_Photo);
            return Ok();
        }
    }
}
