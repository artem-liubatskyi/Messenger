using Messenger.Data;
using Messenger.Data.Entities;
using Messenger.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.DataAccess
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MessengerDbContext context;

        public MessageRepository(MessengerDbContext context)
        {
            this.context = context;
        }

        public async Task<Message> Add(Message entity)
        {
            var result = await context.Messages.AddAsync(entity);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public void Delete(Message entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public void Delete(IReadOnlyCollection<Message> messages)
        {
            context.RemoveRange(messages);
            context.SaveChanges();
        }

        public async Task<Message> Get(string messageId)
        {
            return await context.Messages.FindAsync(messageId);
        }
        public async Task<IEnumerable<Message>> Get(string chatId, int skipCount, int takeCount)
        {
            return await context.Messages.Where(x=>x.ChatId.ToString() == chatId)
                .AsNoTracking()
                .Skip(skipCount)
                .Take(takeCount)
                .ToArrayAsync();
        }
        public async Task<Message> Update(Message entity)
        {
            var messageEntity = context.Messages.Update(entity).Entity;
            await context.SaveChangesAsync();
            return messageEntity;
        }
    }
}
