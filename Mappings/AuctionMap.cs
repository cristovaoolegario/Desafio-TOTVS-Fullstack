using DesafioFullStackTotvs.Models;

namespace DesafioFullStackTotvs.Mappings
{
    public class AuctionMap : EntityTypeConfiguration<Auction>
    {
        public AuctionMap(){
            ToTable("Auctions");

            HasKey(x => x.Id);

            Property(x => x.Name).HasMaxLength(120).IsRequired();
            Property(x => x.InitialValue).IsRequired();
            Property(x => x.WasUsed).IsRequired();
            Property(x => x.OpeningDate).IsRequired();
            Property(x => x.TerminationDate).IsRequired();

            HasRequired(x => x.User);
        }
    }
}