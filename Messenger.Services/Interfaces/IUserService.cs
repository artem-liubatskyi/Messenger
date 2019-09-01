using Messenger.Data.Entities;
using Messenger.Services.Defenitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.Services.Interfaces
{
    public interface IUserService
    {
        ServiceResult<User> Create(User user);
        ServiceResult<User> Update(User user);
        ServiceResult<User> RestorePassword(User user);
        ServiceResult<User> Authenticate(User user);
        ServiceResult<User> AddPermission(UserPermission permission);
        ServiceResult<User> RemovePermission(UserPermission permission);
    }
}
