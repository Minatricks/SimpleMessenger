using Chat.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Db.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder
               .ToTable("Users", "dbo")
               .HasKey(x => x.Id);

            builder
                .Property(x => x.Role)
                .IsRequired();

            builder
                .HasOne(x => x.Profile)
                .WithOne(x => x.User)
                .HasForeignKey<UsersProfile>(x => x.Id);

            builder
                .HasMany(x => x.Contacts)
                .WithOne(x => x.User);
        }
    }
}
