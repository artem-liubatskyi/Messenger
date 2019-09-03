using Messenger.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.DataAccess.IoC
{
    public static class DataAccessDependenciesRegistrator
    {
        public static void AddMessengerDataAccessDependencies(this IServiceCollection services)
        {
            services.AddTransient<IChatRepository, ChatRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IUserChatRepository, UserChatRepository>();
        }
    }
}
