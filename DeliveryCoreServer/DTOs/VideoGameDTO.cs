using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCoreServer.DTOs
{
    public class VideoGameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Platform { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }

        public string CountryPublished { get; set; }
        public DateTime? ReleaseDate { get; set; }

    }
}
