using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCoreServer.ViewModels
{
    public class VideoGameWithCountry
    {
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string CountryPublished { get; set; }
        public DateTime? ReleaseDate { get; set; }

    }
}
