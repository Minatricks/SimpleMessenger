using Chat.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Db.Configuration
{
    public class ContactsEntityConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {

            builder
                .ToTable("Contacts", "dbo");

            builder
              .Property(x => x.Id)
              .HasColumnName("RelationshipId")
              .IsRequired();

            builder
                .Property(x => x.MyId)
                .HasColumnName("MyId");

            builder
                .Property(x => x.FriendId)
                .HasColumnName("ContactId");


            builder
                .HasOne(x => x.FriendUser)
                .WithMany(x => x.MyContacts)
                .HasForeignKey(x => x.FriendId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.MyUser)
                .WithMany(x => x.IinFriendContacts)
                .HasForeignKey(x => x.MyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
