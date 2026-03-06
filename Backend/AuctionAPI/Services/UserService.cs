using AuctionAPI.Entities;
using AuctionAPI.Interfaces;

namespace AuctionAPI.Services
{
    public class UserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User> Register(User user)
        {
            return await _userRepo.CreateUser(user);
        }

        public async Task<User?> Login(string email, string password)
        {
            var user = await _userRepo.GetUserByEmail(email);

            if (user == null)
                return null;

            if (user.Password != password)
                return null;

            return user;
        }
    }
}