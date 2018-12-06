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
        public DbSet<Audiction> Audictions { get; set; }
        public DbSet<AudictionBid> AudictionBids { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new AudictionMap());
            modelBuilder.Configurations.Add(new AudictionBidMap());
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
