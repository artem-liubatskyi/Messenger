using Messenger.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Interfaces
{
    public interface IMessageRepository
    {
        Task<Message> Add(Message entity);
        Task<Message> Get(string messageId);
        Task<Message> Update(Message entity);
        void Delete(Message entity);
        Task<IEnumerable<Message>> GetUserMessagesByChatId(string userId, string chatId);
        void Delete(IReadOnlyCollection<Message> messages);
    }
}
