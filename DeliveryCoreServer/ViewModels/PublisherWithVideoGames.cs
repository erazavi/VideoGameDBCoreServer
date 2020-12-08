using DeliveryCoreServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCoreServer.ViewModels
{
    public class PublisherWithVideoGames
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public List<VideoGames> VideoGames { get; set; }
    }
}
