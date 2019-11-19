using Chat.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Db
{
    public interface IChatDbContext
    {
        DbSet<User> Users { get; set; }

        public DbSet<UsersProfile> Profiles { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken token = default);

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
