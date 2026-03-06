using AuctionAPI.Entities;
using AuctionAPI.Interfaces;

namespace AuctionAPI.Services
{
    public class AuctionService
    {
        private readonly IAuctionRepo _auctionRepo;

        public AuctionService(IAuctionRepo auctionRepo)
        {
            _auctionRepo = auctionRepo;
        }

        public async Task<List<Auction>> GetAllAuctions()
        {
            return await _auctionRepo.GetAllAuctions();
        }

        public async Task<Auction?> GetAuctionById(int id)
        {
            return await _auctionRepo.GetAuctionById(id);
        }

        public async Task<List<Auction>> SearchAuctions(string title)
        {
            return await _auctionRepo.SearchAuctions(title);
        }

        public async Task<Auction> CreateAuction(Auction auction)
        {
            auction.StartDate = DateTime.Now;
            auction.CurrentPrice = auction.StartPrice;

            return await _auctionRepo.CreateAuction(auction);
        }

        public async Task<bool> DeleteAuction(int id)
        {
            var auction = await _auctionRepo.GetAuctionById(id);

            if (auction == null)
                return false;

            await _auctionRepo.DeleteAuction(auction);

            return true;
        }
    }
}