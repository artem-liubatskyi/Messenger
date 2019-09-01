using Messenger.Data.Entities;

namespace Messenger.DataAccess.Interfaces
{
    public interface IMessageRepository
    {
        Message Add(Message entity);
        Message Get(string messageId);
        Message Update(Message entity);
        void Delete(string messageId);
    }
}
