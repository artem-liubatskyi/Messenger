using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.Data.Entities
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string SenderId { get; set; }
        public User Sender { get; set; }
        public Guid ChatId { get; set; }
        public Chat Chat { get; set; }
        public string Content { get; set; }
        public DateTime Added { get; set; }
        public bool IsReaded { get; set; }
        public bool IsEdited { get; set; }
        public long ViewsCount { get; set; }

        public Message(string senderId, string chatId, string content)
        {
            SenderId = senderId;
            ChatId = new Guid(chatId);
            Content = content;
            Added = DateTime.UtcNow;
        }
    }
}
