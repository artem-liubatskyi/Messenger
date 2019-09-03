using Messenger.Data.Entities;
using Messenger.DataAccess.Interfaces;
using Messenger.Services.Defenitions;
using Messenger.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository messageRepository;
        public async Task<ServiceResult<Message>> Add(Message message)
        {
            var messageEntity = await messageRepository.Add(message);
            return new ServiceResult<Message>(messageEntity);
        }

        public async Task<ServiceResult<Message>> Delete(string messageId)
        {
            var messageEntity = await messageRepository.Get(messageId);

            if (messageEntity == null)
                return new ServiceResult<Message>($"No message with id {messageId}");

            messageRepository.Delete(messageEntity);

            return new ServiceResult<Message>(messageEntity);
        }

        public async Task<ServiceResult<Message>> Edit(Message message)
        {
            var messageEntity = await messageRepository.Get(message.Id.ToString());

            if (messageEntity == null)
                return new ServiceResult<Message>($"No message with id {message.Id.ToString()}");

            messageEntity = await messageRepository.Update(message);

            return new ServiceResult<Message>(messageEntity);
        }
    }
}
