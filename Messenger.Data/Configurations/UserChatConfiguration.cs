using Messenger.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Data.Configurations
{
    class UserChatConfiguration : IEntityTypeConfiguration<UserChat>
    {
        public void Configure(EntityTypeBuilder<UserChat> builder)
        {
            builder.ToTable("UserChats");

            builder.HasKey(x => new { x.UserId, x.ChatId });

            builder.HasOne(x => x.Chat)
                 .WithMany(x => x.Users)
                 .HasForeignKey(x => x.ChatId);
        }
    }
}
