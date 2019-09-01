using Messenger.Data.Entities;
using Messenger.Services.Defenitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.Services.Interfaces
{
    public interface IChatService
    {
        ServiceResult<Chat> Create(Chat chat);
        ServiceResult<Chat> Update(Chat chat);
        ServiceResult<Chat> Delete(string chatId);
        ServiceResult<Chat> ClearHistory(string chatId);
        ServiceResult<Chat> AddUserToChat(string chatId, string userId);
        ServiceResult<Chat> RemoveUserFromChat(string chatId, string userId);
    }
}
