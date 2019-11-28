using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Chat.Db
{
    public static class Bootstrap
    {
        public static IServiceCollection AddChatDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IChatDbContext,ChatDbContext>(option =>
            {
                var connectionString = configuration.GetConnectionString("ChatDb");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception("DB ConnectionString is empty");
                }

                option.UseSqlServer(connectionString);
            }, ServiceLifetime.Transient);

            return services;
        }
    }
}
