using System;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AuctionAPI.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<Auction>? Auctions { get; set; }

        public ICollection<Bid>? Bids { get; set; }
    }
}
