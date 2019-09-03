using System.Threading.Tasks;
using Messenger.Data.Entities;

namespace Messenger.DataAccess.Interfaces
{
    public interface IUserChatRepository
    {
        Task<UserChat> Add(UserChat userChat);
        Task<UserChat> Get(string userId, string chatId);
        void Delete(UserChat userChatEntity);
    }
}
