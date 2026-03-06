using AuctionAPI.Entities;

namespace AuctionAPI.Interfaces
{
    public interface IUserRepo
    {
        Task<User> CreateUser(User user);

        Task<User?> GetUserByEmail(string email);

        Task<User?> GetUserById(int id);
    }
}
