﻿using System;
using System.Collections.Generic;

namespace Messenger.Data.Entities
{
    public class UserChat
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public Guid ChatId { get; set; }
        public virtual Chat Chat { get; set; }
        public bool Notify { get; set; }
    }
}
