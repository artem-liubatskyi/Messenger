using Messenger.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Services.IoC
{
    public static class ServicesDependenciesRegistrator
    {
        public static void AddMessengerServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
