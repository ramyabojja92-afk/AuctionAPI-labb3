namespace AuctionAPI.DTOs
{
    public class CreateBidDto
    {
        public decimal Amount { get; set; }

        public int UserId { get; set; }

        public int AuctionId { get; set; }
    }
}
