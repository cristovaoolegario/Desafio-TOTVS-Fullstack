using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioFullStackTotvs.Models {
    public class AuctionBid {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AuctionBidID { get; set; }
        public long BidPrice { get; set; }        
        public string UserId {get; set;}
        [ForeignKey("UserForeignKey")]
        public virtual User User {get; set;}
        public string AuctionId { get; set; }        
        [ForeignKey("AuctionForeignKey")]
        public virtual Auction Auction {get; set;}
    }
}