using Messenger.Data.Entities;
using Messenger.Services.Defenitions;
using System.Threading.Tasks;

namespace Messenger.Services.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResult<User>> Create(User user, string password);
        Task<ServiceResult<User>> Update(User user);
        Task<ServiceResult<User>> RestorePassword(User user);
        Task<ServiceResult<User>> Authenticate(string userName, string password, bool rememberMe);
        Task<ServiceResult<User>> AddPermission(UserPermission permission);
        Task<ServiceResult<User>> RemovePermission(UserPermission permission);
    }
}
