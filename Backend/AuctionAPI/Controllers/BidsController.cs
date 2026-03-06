using AuctionAPI.DTOs;
using AuctionAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuctionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidsController : ControllerBase
    {
        private readonly BidService _bidService;

        public BidsController(BidService bidService)
        {
            _bidService = bidService;
        }

        [HttpGet("auction/{auctionId}")]
        public async Task<IActionResult> GetBids(int auctionId)
        {
            var bids = await _bidService.GetBidsByAuction(auctionId);
            return Ok(bids);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceBid(CreateBidDto dto)
        {
            var bid = await _bidService.PlaceBid(dto.AuctionId, dto.UserId, dto.Amount);

            if (bid == null)
                return BadRequest();

            return Ok(bid);
        }
    }
}