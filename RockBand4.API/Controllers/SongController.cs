using System;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using RockBand4.API.Services;
using RockBand4.API.Models;

namespace RockBand4.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : ControllerBase
    {
        private readonly ILogger<SongController> _logger;
        private readonly ISongService _songService;

        public SongController(ILogger<SongController> logger, ISongService songService)
        {
            _songService = songService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<PersistedSong>> Get()
        {
            return await _songService.GetAll();
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<PersistedSong>> Get(int id)
        {
            var result = await _songService.Get(id);
            if (result != default)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<PersistedSong>> Insert(PersistedSong dto)
        {
            if (dto.Id != null)
            {
                return BadRequest("Id cannot be set for insert action.");
            }

            var id = await _songService.Create(dto);
            if (id != default)
            {
                return CreatedAtRoute("Get", new { id = id }, dto);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult<PersistedSong>> Update(PersistedSong dto)
        {
            if (dto.Id == null)
            {
                return BadRequest("Id should be set for insert action.");
            }

            var result = await _songService.Update(dto);
            if (result > 0)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PersistedSong>> Delete(int id)
        {
            var result = await _songService.Delete(id);
            if (result > 0)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}

