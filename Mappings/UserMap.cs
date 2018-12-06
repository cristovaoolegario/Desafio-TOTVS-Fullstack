using DesafioFullStackTotvs.Models;

namespace DesafioFullStackTotvs.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap(){
            ToTable("Users");

            HasKey(x => x.Id);

            Property(x => x.Name).HasMaxLength(120).IsRequired();
            Property(x => x.Email).HasMaxLength(100).IsRequired();
            Property(x => x.User).HasMaxLength(30).IsRequired();
            Property(x => x.Password).HasMaxLength(50).IsRequired();
            Property(x => x.Cpf).HasMaxLength(11).IsRequired();
            Property(x => x.IsAdmin).IsRequired();
            Property(x => x.IsActive).IsRequired();
        }
    }
}