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
    public class PlatformsController : ControllerBase
    {
        private readonly VideoGameDBContext _context;

        public PlatformsController(VideoGameDBContext context)
        {
            _context = context;
        }

        // GET: api/Platforms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Platform>>> GetPlatforms()
        {
            return await _context.Platforms.ToListAsync();
        }

        // GET: api/Platforms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Platform>> GetPlatform(int id)
        {
            var platform = await _context.Platforms.FindAsync(id);

            if (platform == null)
            {
                return NotFound();
            }

            return platform;
        }

        // PUT: api/Platforms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlatform(int id, Platform platform)
        {
            if (id != platform.Id)
            {
                return BadRequest();
            }

            _context.Entry(platform).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatformExists(id))
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

        // POST: api/Platforms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Platform>> PostPlatform(Platform platform)
        {
            _context.Platforms.Add(platform);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlatformExists(platform.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlatform", new { id = platform.Id }, platform);
        }

        // DELETE: api/Platforms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Platform>> DeletePlatform(int id)
        {
            var platform = await _context.Platforms.FindAsync(id);
            if (platform == null)
            {
                return NotFound();
            }

            _context.Platforms.Remove(platform);
            await _context.SaveChangesAsync();

            return platform;
        }

        private bool PlatformExists(int id)
        {
            return _context.Platforms.Any(e => e.Id == id);
        }
    }
}
