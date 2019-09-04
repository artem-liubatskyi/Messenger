using Messenger.Data.Entities;
using Messenger.DataAccess.Interfaces;
using Messenger.Services.Defenitions;
using Messenger.Services.Interfaces;
using System.Threading.Tasks;

namespace Messenger.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository messageRepository;
        private readonly IUserChatRepository userChatRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public async Task<ServiceResult<Message>> Add(Message message)
        {
            var userChatEntity = userChatRepository.Get(message.SenderId, message.ChatId.ToString());

            if (userChatEntity == null)
                return new ServiceResult<Message>("There is no reference between specified user and chat");

            var messageEntity = await messageRepository.Add(message);

            return new ServiceResult<Message>(messageEntity);
        }

        public async Task<ServiceResult<Message>> Delete(string messageId, string userId)
        {
            var messageEntity = await messageRepository.Get(messageId);

            if (messageEntity == null)
                return new ServiceResult<Message>($"No message with id {messageId}");

            if (messageEntity.SenderId != userId)
                return new ServiceResult<Message>("You can't delete this message");

            messageRepository.Delete(messageEntity);

            return new ServiceResult<Message>(messageEntity);
        }

        public async Task<ServiceResult<Message>> Edit(Message message)
        {
            var messageEntity = await messageRepository.Get(message.Id.ToString());

            if (messageEntity == null)
                return new ServiceResult<Message>($"No message with id {message.Id.ToString()}");

            if (messageEntity.SenderId != message.SenderId)
                return new ServiceResult<Message>("You can't edit this message");

            messageEntity = await messageRepository.Update(message);

            return new ServiceResult<Message>(messageEntity);
        }
    }
}
