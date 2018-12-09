using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioFullStackTotvs.Models {
    public class Auction {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AuctionID { get; set; }
        public string Name { get; set; }
        public long InitialValue {get; set;}
        public string WasUsed { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserForeignKey")]
        public virtual User User {get; set;}
        public DateTime OpeningDate { get; set; }
        public DateTime TerminationDate { get; set;}
    }
}