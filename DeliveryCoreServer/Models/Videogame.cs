using System;
using System.Collections.Generic;

#nullable disable

namespace DeliveryCoreServer.Models
{
    public partial class Videogame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PlatformId { get; set; }
        public int? PublisherId { get; set; }
        public int? DeveloperId { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public virtual Developer Developer { get; set; }
        public virtual Platform Platform { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
