using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Messenger.Data.Entities
{
    public class User : IdentityUser
    {
        public string ImagePath { get; set; }
        public DateTime LastSeen { get; set; }
        public bool IsOnline { get; set; }
        public Guid SettingsId { get; set; }
        public UserSettings Settings { get; set; }
        public ICollection<UserChat> Chats { get; set; }
    }
}
