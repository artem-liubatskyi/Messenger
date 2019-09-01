using Messenger.Data.Entities;
using System.Linq;

namespace Messenger.DataAccess.Interfaces
{
    public interface IChatRepository
    {
        IQueryable<Chat> GetUsersChats(string userId);
        IQueryable<UserChat> GetMembers(string chatId);
        void Delete(string chatId);
        Chat Add(Chat entity);
        Chat Update(Chat entity);
        Chat GetWithMesages(string chatId);
    }
}
