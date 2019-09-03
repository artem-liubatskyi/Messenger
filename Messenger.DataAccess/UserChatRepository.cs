using Messenger.Data;
using Messenger.Data.Entities;
using Messenger.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.DataAccess
{
    public class UserChatRepository : IUserChatRepository
    {
        private readonly MessengerDbContext context;

        public UserChatRepository(MessengerDbContext context)
        {
            this.context = context;
        }

        public async Task<UserChat> Add(UserChat entity)
        {
            var result = await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public void Delete(UserChat entity)
        {
            context.UserChats.Remove(entity);
            context.SaveChanges();
        }

        public async Task<UserChat> Get(string userId, string chatId)
        {
            return await context.UserChats
                .Where(x => x.UserId == userId && x.ChatId.ToString() == chatId)
                .FirstOrDefaultAsync();
        }
    }
}
