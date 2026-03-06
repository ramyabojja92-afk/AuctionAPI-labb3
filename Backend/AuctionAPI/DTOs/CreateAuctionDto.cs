namespace AuctionAPI.DTOs
{
    public class CreateAuctionDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal StartPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
    }
}
