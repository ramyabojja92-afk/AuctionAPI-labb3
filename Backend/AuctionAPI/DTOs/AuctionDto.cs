namespace AuctionAPI.DTOs
{
    public class AuctionDto
    {
        public int AuctionId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal CurrentPrice { get; set; }

        public DateTime EndDate { get; set; }

        public int UserId { get; set; }
    }
}
