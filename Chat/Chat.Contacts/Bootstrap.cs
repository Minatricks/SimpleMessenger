using Microsoft.Extensions.DependencyInjection;

namespace Chat.Contacts
{
    public static class Bootstrap
    {
        public static IServiceCollection AddContactService(this IServiceCollection services)
        {
            return services.AddScoped<IContactService, ContactService>();
        }
    }
}
