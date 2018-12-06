using DesafioFullStackTotvs.Models;

namespace DesafioFullStackTotvs.Mappings
{
    public class AudictionBidMap : EntityTypeConfiguration<AudictionBid>
    {
        public AudictionBidMap(){
            ToTable("AudictionBids");

            HasKey(x => x.Id);

            Property(x => x.BidPrice).IsRequired();

            HasRequired(x => x.User);
            HasRequired(x => x.Audiction);
        }
    }
}