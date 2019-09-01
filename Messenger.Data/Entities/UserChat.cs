using System;
using System.Collections.Generic;

namespace Messenger.Data.Entities
{
    class UserChat
    {
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
        public bool Notify { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}
