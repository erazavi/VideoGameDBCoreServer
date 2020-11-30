using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeliveryCoreServer.Models;

namespace DeliveryCoreServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideogamesController : ControllerBase
    {
        private readonly VideoGameDBContext _context;

        public VideogamesController(VideoGameDBContext context)
        {
            _context = context;
        }

        // GET: api/Videogames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Videogame>>> GetVideogames()
        {
            return await _context.Videogames.ToListAsync();
        }

        // GET: api/Videogames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOs.VideoGameDTO>> GetVideogame(int id)
        {
            var videogame = await _context.Videogames
                .Include(v => v.Platform)
                .Include(v => v.Publisher)
                .Include(v => v.Developer)
                .Where(v => v.Id == id)
                .FirstOrDefaultAsync();

            if (videogame == null)
            {
                return NotFound();
            }

            var videogameDTO = new DTOs.VideoGameDTO()
            {
                Name = videogame.Name,
                Publisher = videogame.Publisher.Name,
                Platform = videogame.Platform.Name,
                Developer = videogame.Developer.Name,
                ReleaseDate = videogame.ReleaseDate,
                CountryPublished = videogame.Publisher.Country
            };

            return videogameDTO;
        }

        // PUT: api/Videogames/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideogame(int id, Videogame videogame)
        {
            if (id != videogame.Id)
            {
                return BadRequest();
            }

            _context.Entry(videogame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideogameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Videogames
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Videogame>> PostVideogame(Videogame videogame)
        {
            _context.Videogames.Add(videogame);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VideogameExists(videogame.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVideogame", new { id = videogame.Id }, videogame);
        }

        // DELETE: api/Videogames/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Videogame>> DeleteVideogame(int id)
        {
            var videogame = await _context.Videogames.FindAsync(id);
            if (videogame == null)
            {
                return NotFound();
            }

            _context.Videogames.Remove(videogame);
            await _context.SaveChangesAsync();

            return videogame;
        }

        private bool VideogameExists(int id)
        {
            return _context.Videogames.Any(e => e.Id == id);
        }
    }
}
