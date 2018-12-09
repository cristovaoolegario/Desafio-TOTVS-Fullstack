using DesafioFullStackTotvs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DesafioFullStackTotvs.Models
{
    public class DesafioFullStackTotvsDataContext : DbContext
    {
        public DesafioFullStackTotvsDataContext(DbContextOptions<DesafioFullStackTotvsDataContext> options)
            : base (options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<AuctionBid> AuctionBids { get; set; }       
    }
}
