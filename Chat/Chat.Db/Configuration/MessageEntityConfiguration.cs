﻿using Chat.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Db.Configuration
{
    public class MessageEntityConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages", "dbo").HasKey(x => x.Id);

            builder
               .Property(x => x.Id)
               .ValueGeneratedOnAdd();

            builder
                .HasOne(x => x.SenderUser)
                .WithMany(x => x.SendMessages)
                .HasForeignKey(x => x.IdSender)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.RecipientUser)
                .WithMany(x => x.ReceivedMessages)
                .HasForeignKey(x => x.IdRecipient)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
