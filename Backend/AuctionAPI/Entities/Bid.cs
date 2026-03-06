using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionAPI.Entities
{
    public class Bid
    {
        public int BidId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public DateTime BidDate { get; set; }

        public int UserId { get; set; }

        public int AuctionId { get; set; }

        public User? User { get; set; }

        public Auction? Auction { get; set; }
    }
}
