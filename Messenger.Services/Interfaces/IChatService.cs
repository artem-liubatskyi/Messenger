using Messenger.Data.Entities;
using Messenger.Services.Defenitions;
using System.Threading.Tasks;

namespace Messenger.Services.Interfaces
{
    public interface IChatService
    {
        Task<ServiceResult<Chat>> Create(Chat chat);
        Task<ServiceResult<Chat>> Update(Chat chat);
        Task<ServiceResult<Chat>> Delete(string chatId);
        Task<ServiceResult<Chat>> ClearHistory(string chatId);
        Task<ServiceResult<Chat>> AddUserToChat(string chatId, string userId);
        Task<ServiceResult<Chat>> RemoveUserFromChat(string chatId, string userId);
    }
}
