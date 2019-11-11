using Chat.Message.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Message
{
    public static class Bootstrap
    {
        public static IServiceCollection AddMessageService(this IServiceCollection services)
        {
            return services.AddScoped<IMessageService, MessageService>();
        }

        public static IApplicationBuilder AddMessageHub(this IApplicationBuilder app)
        {
           return app.UseSignalR(routes =>
            {
                routes.MapHub<MessageHub>("/messages");
            });
        }
    }
}
