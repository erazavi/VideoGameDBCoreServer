using DeliveryCoreServer.Models;
using DeliveryCoreServer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCoreServer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherWithVideoGamesController : ControllerBase
    {
        private readonly VideoGameDBContext _context;

        public PublisherWithVideoGamesController(VideoGameDBContext context)
        {
            _context = context;
        }

        // GET: api/PublishersWithVideoGames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublisherWithVideoGames>>> GetPublishersWithVideoGames()
        {
            var publishersWithGames = await _context.Publishers.Select(p => new PublisherWithVideoGames
            {
                Name = p.Name,
                VideoGames = p.VideoGames.Select(v => v.Name).ToList()
            }).ToListAsync();
            return publishersWithGames;
        }
    }
}
