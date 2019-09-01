using Messenger.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Messenger.DataAccess.Interfaces
{
    public interface IChatRepository
    {
        IQueryable<Chat> GetUserChats(string userId)
    }
}
