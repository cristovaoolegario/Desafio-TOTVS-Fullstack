using System.Collections.Generic;

namespace DesafioFullStackTotvs.Models {
    public class Audiction {
        public long Id { get; set; }
        public string Name { get; set; }
        public long InitialValue {get; set;}
        public string WasUsed { get; set; }
        public string UserId { get; set; }
        public virtual User User {get; set;}
        public Date OpeningDate { get; set; }
        public Date TerminationDate { get; set;}
    }
}