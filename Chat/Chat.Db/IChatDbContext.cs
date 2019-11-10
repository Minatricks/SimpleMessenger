using Chat.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Db
{
    public interface IChatDbContext
    {
        DbSet<Users> Users { get; set; }

        public DbSet<UsersProfile> Profiles { get; set; }

        public DbSet<Messages> Messages { get; set; }

        public DbSet<Contacts> Contacts { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
