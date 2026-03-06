using AuctionAPI.DTOs;
using AuctionAPI.Entities;
using AuctionAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuctionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password
            };

            var createdUser = await _userService.Register(user);

            return Ok(createdUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            var user = await _userService.Login(dto.Email, dto.Password);

            if (user == null)
                return Unauthorized("Invalid email or password");

            return Ok(user);
        }
    }
}