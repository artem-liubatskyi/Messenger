using Messenger.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messenger.DataAccess.Interfaces
{
    public interface IChatRepository
    {
        Task<IEnumerable<Chat>> GetUsersChats(string userId);
        Task<IEnumerable<UserChat>> GetMembers(string chatId);
        void Delete(Chat chat);
        Task<Chat> Get(string chatId);
        Task<Chat> Add(Chat entity);
        Task<Chat> Update(Chat entity);
        Task<Chat> GetWithMesages(string chatId);
    }
}
