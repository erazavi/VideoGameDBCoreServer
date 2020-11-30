using System;
using System.Collections.Generic;

#nullable disable

namespace DeliveryCoreServer.Models
{
    public partial class Platform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
