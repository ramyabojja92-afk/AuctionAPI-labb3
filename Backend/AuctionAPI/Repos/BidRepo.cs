using AuctionAPI.Data;
using AuctionAPI.Entities;
using AuctionAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuctionAPI.Repos
{
    public class BidRepo : IBidRepo
    {
        private readonly AuctionDbContext _context;

        public BidRepo(AuctionDbContext context)
        {
            _context = context;
        }

        public async Task<List<Bid>> GetBidsByAuction(int auctionId)
        {
            return await _context.Bids
                .Where(b => b.AuctionId == auctionId)
                .ToListAsync();
        }

        public async Task<Bid> CreateBid(Bid bid)
        {
            _context.Bids.Add(bid);
            await _context.SaveChangesAsync();
            return bid;
        }
    }
}
