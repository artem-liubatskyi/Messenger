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
        Task<Chat> Add(Chat entity);
        Chat Update(Chat entity);
        Task<Chat> GetWithMesages(string chatId);
    }
}
