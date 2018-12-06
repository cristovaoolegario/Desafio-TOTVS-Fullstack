using System.Collections.Generic;

namespace DesafioFullStackTotvs.Models {
    public class AuctionBid {
        public long Id { get; set; }
        public long BidPrice { get; set; }
        public string UserId {get; set;}
        public virtual User User {get; set;}
        public string AuctionId { get; set; }
        public virtual Auction Auction {get; set;}
    }
}