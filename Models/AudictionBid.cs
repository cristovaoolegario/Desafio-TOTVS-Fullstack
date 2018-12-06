using System.Collections.Generic;

namespace DesafioFullStackTotvs.Models {
    public class AudictionBid {
        public long Id { get; set; }
        public long BidPrice { get; set; }
        public string UserId {get; set;}
        public virtual User User {get; set;}
        public string AudictionId { get; set; }
        public virtual Audiction Audiction {get; set;}
    }
}