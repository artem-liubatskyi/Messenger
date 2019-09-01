using Messenger.Data.Entities;
using Messenger.Services.Defenitions;
using System.Threading.Tasks;

namespace Messenger.Services.Interfaces
{
    public interface IMessageService
    {
        Task<ServiceResult<Message>> Add(Message message);
        Task<ServiceResult<Message>> Edit(Message message);
        Task<ServiceResult<Message>> Delete(string messageId);
    }
}
