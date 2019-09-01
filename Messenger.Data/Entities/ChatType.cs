using System.ComponentModel.DataAnnotations;

namespace Messenger.Data.Entities
{
    class ChatType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
