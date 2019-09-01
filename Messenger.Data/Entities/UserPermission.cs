using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.Data.Entities
{
    public class UserPermission
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
        public Guid ChatId { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
