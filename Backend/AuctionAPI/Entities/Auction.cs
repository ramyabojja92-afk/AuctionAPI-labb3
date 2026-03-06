using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace AuctionAPI.Entities
{
    public class Auction
    {
        public int AuctionId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal StartPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentPrice { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }

        public ICollection<Bid>? Bids { get; set; }
    }
}
