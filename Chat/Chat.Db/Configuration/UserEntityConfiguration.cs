using Chat.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Db.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
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

        }
    }
}
