using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Messenger.Data.Entities
{
    class User : IdentityUser
    {
        public string ImagePath { get; set; }
        public DateTime LastSeen { get; set; }
        public bool IsOnline { get; set; }
        public Guid SettingsId { get; set; }
        public UserSettings Settings { get; set; }
        public virtual ICollection<User> BlockList { get; set; }
    }
}
