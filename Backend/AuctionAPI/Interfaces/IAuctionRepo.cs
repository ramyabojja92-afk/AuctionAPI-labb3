using AuctionAPI.Entities;

namespace AuctionAPI.Interfaces
{
    public interface IAuctionRepo
    {
        Task<List<Auction>> GetAllAuctions();

        Task<Auction?> GetAuctionById(int id);
        Task<Auction> UpdateAuction(Auction auction);

        Task<List<Auction>> SearchAuctions(string title);

        Task<Auction> CreateAuction(Auction auction);

        Task DeleteAuction(Auction auction);
    }
}
