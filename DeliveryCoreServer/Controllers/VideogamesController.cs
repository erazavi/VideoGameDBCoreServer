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
    public class VideoGamesController : ControllerBase
    {
        private readonly VideoGameDBContext _context;

        public VideoGamesController(VideoGameDBContext context)
        {
            _context = context;
        }

        // GET: api/VideoGames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoGames>>> GetVideoGames()
        {
            return await _context.VideoGames.ToListAsync();
        }

        // GET: api/VideoGames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGames>> GetVideoGames(int id)
        {
            var videoGames = await _context.VideoGames.FindAsync(id);

            if (videoGames == null)
            {
                return NotFound();
            }

            return videoGames;
        }

        // PUT: api/VideoGames/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideoGames(int id, VideoGames videoGames)
        {
            if (id != videoGames.VideoGameId)
            {
                return BadRequest();
            }

            _context.Entry(videoGames).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoGamesExists(id))
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

        // POST: api/VideoGames
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VideoGames>> PostVideoGames(VideoGames videoGames)
        {
            _context.VideoGames.Add(videoGames);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVideoGames", new { id = videoGames.VideoGameId }, videoGames);
        }

        // DELETE: api/VideoGames/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VideoGames>> DeleteVideoGames(int id)
        {
            var videoGames = await _context.VideoGames.FindAsync(id);
            if (videoGames == null)
            {
                return NotFound();
            }

            _context.VideoGames.Remove(videoGames);
            await _context.SaveChangesAsync();

            return videoGames;
        }

        private bool VideoGamesExists(int id)
        {
            return _context.VideoGames.Any(e => e.VideoGameId == id);
        }
    }
}
