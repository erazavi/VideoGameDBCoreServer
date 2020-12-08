using DeliveryCoreServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCoreServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherWithVideoGamesController
    {
        private readonly VideoGameDBContext _context;
    }
}
