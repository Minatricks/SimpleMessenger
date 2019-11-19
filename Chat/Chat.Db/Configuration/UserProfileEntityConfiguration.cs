using Chat.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Db.Configuration
{
    public class UserProfileEntityConfiguration : IEntityTypeConfiguration<UsersProfile>
    {
        public void Configure(EntityTypeBuilder<UsersProfile> builder)
        {
            builder
                .ToTable("UserProfiles", "dbo")
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();
        }
    }
}
