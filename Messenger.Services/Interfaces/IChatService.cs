﻿using Messenger.Data.Entities;
using Messenger.Services.Defenitions;
using System.Threading.Tasks;

namespace Messenger.Services.Interfaces
{
    public interface IChatService
    {
        Task<ServiceResult<Chat>> Create(Chat chat);
        Task<ServiceResult<Chat>> Update(Chat chat);
        Task<ServiceResult<Chat>> Delete(string chatId);
        Task<ServiceResult<Chat>> ClearHistory(string userId, string chatId);
        Task<ServiceResult<UserChat>> AddUserToChat(string chatId, string userId);
        Task<ServiceResult<UserChat>> RemoveUserFromChat(string chatId, string userId);
    }
}
