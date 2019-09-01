using Messenger.Data.Entities;
using Messenger.Services.Defenitions;

namespace Messenger.Services.Interfaces
{
    public interface IMessageService
    {
        ServiceResult<Message> Add(Message message);
        ServiceResult<Message> Edit(Message message);
        ServiceResult<Message> Delete(string messageId);
    }
}
