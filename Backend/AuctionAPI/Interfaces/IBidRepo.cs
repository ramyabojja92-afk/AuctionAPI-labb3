using AuctionAPI.Entities;

namespace AuctionAPI.Interfaces
{
    public interface IBidRepo
    {
        Task<List<Bid>> GetBidsByAuction(int auctionId);

        Task<Bid> CreateBid(Bid bid);
    }
}
