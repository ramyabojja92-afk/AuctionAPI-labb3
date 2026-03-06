namespace AuctionAPI.DTOs
{
    public class BidDto
    {
        public int BidId { get; set; }

        public decimal Amount { get; set; }

        public DateTime BidDate { get; set; }

        public int UserId { get; set; }

        public int AuctionId { get; set; }
    }
}
