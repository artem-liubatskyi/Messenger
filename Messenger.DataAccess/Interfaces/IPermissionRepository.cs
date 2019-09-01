using Messenger.Data.Entities;

namespace Messenger.DataAccess.Interfaces
{
    public interface IPermissionRepository
    {
        Permission GetByName();
    }
}
