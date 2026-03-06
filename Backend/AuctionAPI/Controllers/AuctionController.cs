using AuctionAPI.DTOs;
using AuctionAPI.Entities;
using AuctionAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuctionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuctionsController : ControllerBase
    {
        private readonly AuctionService _auctionService;

        public AuctionsController(AuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuctions()
        {
            var auctions = await _auctionService.GetAllAuctions();
            return Ok(auctions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuction(int id)
        {
            var auction = await _auctionService.GetAuctionById(id);

            if (auction == null)
                return NotFound();

            return Ok(auction);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string title)
        {
            var auctions = await _auctionService.SearchAuctions(title);
            return Ok(auctions);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuction(CreateAuctionDto dto)
        {
            var auction = new Auction
            {
                Title = dto.Title,
                Description = dto.Description,
                StartPrice = dto.StartPrice,
                EndDate = dto.EndDate,
                UserId = dto.UserId
            };

            var createdAuction = await _auctionService.CreateAuction(auction);

            return Ok(createdAuction);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuction(int id)
        {
            var result = await _auctionService.DeleteAuction(id);

            if (!result)
                return NotFound();

            return Ok("Auction deleted");
        }
    }
}