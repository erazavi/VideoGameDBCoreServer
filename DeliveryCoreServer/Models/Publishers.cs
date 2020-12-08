
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DeliveryCoreServer.Models
{
    public partial class Publishers
    {
        public Publishers()
        {
            VideoGames = new HashSet<VideoGames>();
        }
        [Key]
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public virtual ICollection<VideoGames> VideoGames { get; set; }
    }
}
