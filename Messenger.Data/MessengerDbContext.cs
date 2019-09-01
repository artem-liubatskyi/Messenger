using Messenger.Data.Configurations;
using Messenger.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Data
{
    public class MessengerDbContext : IdentityDbContext
    {
        public MessengerDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ChatConfiguration())
                .ApplyConfiguration(new MessageConfiguration())
                .ApplyConfiguration(new UserChatConfiguration())
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new UserSettingsConfiguration())
                .ApplyConfiguration(new UserPermissionConfiguration());
        }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatType> ChatTypes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserChat> UserChats { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
    }
}
