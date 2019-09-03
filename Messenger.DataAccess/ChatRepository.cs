using Messenger.Data;
using Messenger.Data.Entities;
using Messenger.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.DataAccess
{
    public class ChatRepository : IChatRepository
    {
        private readonly MessengerDbContext context;

        public ChatRepository(MessengerDbContext context)
        {
            this.context = context;
        }

        public async Task<Chat> Add(Chat entity)
        {
            var result = await context.Chats.AddAsync(entity);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public void Delete(Chat entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                context.Attach(entity);
            }

            context.Remove(entity);
        }

        public async Task<Chat> Get(string chatId)
        {
            return await context.Chats.FirstOrDefaultAsync(x=>x.Id.ToString()==chatId);
        }

        public async Task<IEnumerable<UserChat>> GetMembers(string chatId)
        {
            return await context.UserChats.Where(x => x.ChatId.ToString() == chatId).ToArrayAsync();
        }

        public async Task<IEnumerable<Chat>> GetUsersChats(string userId)
        {
            return await context.UserChats.Where(x => x.UserId == userId)
                .Include(x => x.Chat)
                .AsNoTracking()
                .Select(x => x.Chat)
                .ToArrayAsync();
        }

        public async Task<Chat> GetWithMesages(string chatId)
        {
            return await context.Chats.Where(x => x.Id.ToString() == chatId)
                .Include(x => x.Messages)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Chat> Update(Chat entity)
        {
            var result = context.Update(entity).Entity;
            await context.SaveChangesAsync();
            return result;
        }
    }
}
