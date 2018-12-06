using DesafioFullStackTotvs.Models;
using DesafioFullStackTotvs.Mappings;
using System.Data.Entity;

namespace DesafioFullStackTotvs.DataContexts
{
    public class DesafioFullStackTotvsDataContext : DbContext
    {
        public DevStoreDataContext()
            : base("AzureConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<AuctionBid> AuctionBids { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new AuctionMap());
            modelBuilder.Configurations.Add(new AuctionBidMap());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class DevStoreDataContextInitializer : DropCreateDatabaseIfModelChanges<DevStoreDataContext>
    {
        protected override void Seed(DevStoreDataContext context)
        {
            context.Users.Add(new User {});
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
