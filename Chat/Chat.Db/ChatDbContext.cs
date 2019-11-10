using Chat.Db.Configuration;
using Chat.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Db
{
    public class ChatDbContext : DbContext, IChatDbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
        {
            
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<UsersProfile> Profiles { get; set; }

        public DbSet<Messages> Messages { get; set; }

        public DbSet<Contacts> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MessageEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
