using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.Data.Entities
{
    public class Chat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int ChatTypeId { get; set; }
        public ChatType Type { get; set; }

        public string Description { get; set; }
        public string ImagePath { get; set; }

        public Guid PinnedMessageId { get; set; }
        public Message PinnedMessage { get; set; }

        public virtual ICollection<UserChat> Users { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
