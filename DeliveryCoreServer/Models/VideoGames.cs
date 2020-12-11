using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DeliveryCoreServer.Models
{
    public partial class VideoGames
    {
        [Key]
        public int VideoGameId { get; set; }
        public string Name { get; set; }
        public int PublisherId { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public virtual Publishers Publisher { get; set; }
    }
}
