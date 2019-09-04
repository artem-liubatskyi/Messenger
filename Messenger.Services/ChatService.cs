using Messenger.Data.Entities;
using Messenger.DataAccess.Interfaces;
using Messenger.Services.Defenitions;
using Messenger.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository chatRepository;
        private readonly IMessageRepository messageRepository;
        private readonly IUserChatRepository userChatRepository;
        private readonly UserManager<User> userManager;

        public ChatService(IChatRepository chatRepository, 
            IMessageRepository messageRepository, 
            IUserChatRepository userChatRepository, 
            UserManager<User> userManager)
        {
            this.chatRepository = chatRepository;
            this.messageRepository = messageRepository;
            this.userChatRepository = userChatRepository;
            this.userManager = userManager;
        }

        public async Task<ServiceResult<UserChat>> AddUserToChat(string chatId, string userId)
        {
            var chatEntity = await chatRepository.Get(chatId);

            if (chatEntity == null)
                return new ServiceResult<UserChat>($"No chat with id {chatId}");

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
                return new ServiceResult<UserChat>($"No user with id {userId}");

            var userChatEntity
                = await userChatRepository.Add(new UserChat { UserId = user.Id, ChatId = chatEntity.Id });

            if (userChatEntity == null)
                return new ServiceResult<UserChat>($"Something went wrong)");

            return new ServiceResult<UserChat>(userChatEntity);
        }

        public async Task<ServiceResult<Chat>> ClearHistory(string userId, string chatId)
        {
            var chatEntity = await chatRepository.GetWithMesages(chatId);

            if (chatEntity == null)
                return new ServiceResult<Chat>($"No chat with id {chatId}");

            var messages = chatEntity.Messages.Where(x => x.SenderId == userId);

            if (messages.Count() == 0)
                return new ServiceResult<Chat>("User have no messages in this chat");

            messageRepository.Delete(messages.ToArray());

            return new ServiceResult<Chat>(chatEntity);
        }

        public async Task<ServiceResult<Chat>> Create(Chat chat)
        {
            var chatEntity = await chatRepository.Add(chat);
            return new ServiceResult<Chat>(chatEntity);
        }

        public async Task<ServiceResult<Chat>> Delete(string chatId)
        {
            var chatEntity = await chatRepository.Get(chatId);

            if (chatEntity == null)
                return new ServiceResult<Chat>($"No chat with id: {chatId}");

            chatRepository.Delete(chatEntity);
            return new ServiceResult<Chat>();
        }

        public Task<ServiceResult<Chat>> Get(Chat chat)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<IEnumerable<Message>>> GetMessages(string chatId, int skipCount, int takeCount)
        {
            var chatEntity = await chatRepository.Get(chatId);

            if (chatEntity == null)
                return new ServiceResult<IEnumerable<Message>>($"No chat with id: {chatId}");

            var messages = await messageRepository.Get(chatId, skipCount, takeCount);

            return new ServiceResult<IEnumerable<Message>>(messages);
        }

        public async Task<ServiceResult<UserChat>> RemoveUserFromChat(string chatId, string userId)
        {
            var chatEntity = await chatRepository.Get(chatId);

            if (chatEntity == null)
                return new ServiceResult<UserChat>($"No chat with id {chatId}");

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
                return new ServiceResult<UserChat>($"No user with id {userId}");

            var userChatEntity
                = await userChatRepository.Get(userId, chatId);

            if (userChatEntity == null)
                return new ServiceResult<UserChat>($"Something went wrong)");

            userChatRepository.Delete(userChatEntity);

            return new ServiceResult<UserChat>(userChatEntity);
        }

        public async Task<ServiceResult<Chat>> Update(Chat chat)
        {
            var chatEntity = await chatRepository.Get(chat.Id.ToString());

            if (chatEntity == null)
                return new ServiceResult<Chat>($"No such chat");

            chatEntity = await chatRepository.Update(chat);

            return new ServiceResult<Chat>(chatEntity);
        }
    }
}
