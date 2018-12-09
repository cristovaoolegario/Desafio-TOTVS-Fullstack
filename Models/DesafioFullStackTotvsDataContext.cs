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

        private void ConfiguraCliente(ModelBuilder construtorDeModelos)
        {
            construtorDeModelos.Entity<User>( User =>
            {                  /*etd.ToTable("User");
                  etd.HasKey(c => c.Id).HasName("id");
                  etd.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();
                  etd.Property(c => c.Nome).HasColumnName("nome").HasMaxLength(100);
                  etd.Property(c => c.Email).HasColumnName("email").HasMaxLength(30);*/
            });                
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<AuctionBid> AuctionBids { get; set; }       
    }
}
