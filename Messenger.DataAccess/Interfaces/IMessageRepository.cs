using Messenger.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Interfaces
{
    public interface IMessageRepository
    {
        Message Add(Message entity);
        Message Get(string messageId);
        Message Update(Message entity);
        void Delete(string messageId);
        Task<IEnumerable<Message>> GetUserMessagesByChatId(string userId, string chatId);
        void Delete(IReadOnlyCollection<Message> messages);
    }
}
