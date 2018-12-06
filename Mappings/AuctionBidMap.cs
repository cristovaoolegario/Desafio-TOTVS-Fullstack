using DesafioFullStackTotvs.Models;

namespace DesafioFullStackTotvs.Mappings
{
    public class AuctionBidMap : EntityTypeConfiguration<AuctionBid>
    {
        public AuctionBidMap(){
            ToTable("AuctionBids");

            HasKey(x => x.Id);

            Property(x => x.BidPrice).IsRequired();

            HasRequired(x => x.User);
            HasRequired(x => x.Auction);
        }
    }
}