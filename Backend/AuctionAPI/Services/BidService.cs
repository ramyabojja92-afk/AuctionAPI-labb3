using AuctionAPI.Entities;
using AuctionAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuctionAPI.Services
{
    public class BidService
    {
        private readonly IBidRepo _bidRepo;
        private readonly IAuctionRepo _auctionRepo;

        public BidService(IBidRepo bidRepo, IAuctionRepo auctionRepo)
        {
            _bidRepo = bidRepo;
            _auctionRepo = auctionRepo;
        }

        public async Task<List<Bid>> GetBidsByAuction(int auctionId)
        {
            return await _bidRepo.GetBidsByAuction(auctionId);
        }

        public async Task<Bid?> PlaceBid(int auctionId, int userId, decimal amount)
        {
            var auction = await _auctionRepo.GetAuctionById(auctionId);

            if (auction == null)
                return null;

            // Owner cannot bid
            if (auction.UserId == userId)
                return null;

            // Bid must be higher
            if (amount <= auction.CurrentPrice)
                return null;

            var bid = new Bid
            {
                AuctionId = auctionId,
                UserId = userId,
                Amount = amount,
                BidDate = DateTime.Now
            };

            // save bid first
            var createdBid = await _bidRepo.CreateBid(bid);

            if (createdBid == null)
                return null;

            // update auction price
            auction.CurrentPrice = amount;

            await _auctionRepo.UpdateAuction(auction);

            return createdBid;
        }

    }
}