using AuctionAPI.Data;
using AuctionAPI.Entities;
using AuctionAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuctionAPI.Repos
{
    public class AuctionRepo : IAuctionRepo
    {
        private readonly AuctionDbContext _context;

        public AuctionRepo(AuctionDbContext context)
        {
            _context = context;
        }

        public async Task<List<Auction>> GetAllAuctions()
        {
            return await _context.Auctions
                .Include(a => a.Bids)
                .ToListAsync();
        }

        public async Task<Auction?> GetAuctionById(int id)
        {
            return await _context.Auctions
                .Include(a => a.Bids)
                .FirstOrDefaultAsync(a => a.AuctionId == id);
        }

        public async Task<List<Auction>> SearchAuctions(string title)
        {
            return await _context.Auctions
                .Where(a => a.Title.Contains(title) &&
                            a.EndDate > DateTime.Now)
                .ToListAsync();
        }

        public async Task<Auction> CreateAuction(Auction auction)
        {
            _context.Auctions.Add(auction);
            await _context.SaveChangesAsync();
            return auction;
        }

        public async Task DeleteAuction(Auction auction)
        {
            _context.Auctions.Remove(auction);
            await _context.SaveChangesAsync();
        }

        public async Task<Auction> UpdateAuction(Auction auction)
        {
            _context.Auctions.Update(auction);
            await _context.SaveChangesAsync();
            return auction;
        }
    }
}

