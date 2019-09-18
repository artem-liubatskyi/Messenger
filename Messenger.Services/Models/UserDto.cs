using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.Services.Models
{
    public class UserDto
    {
        public UserDto(string id, string userName, string accessToken, string refreshToken)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            AccessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
            RefreshToken = refreshToken ?? throw new ArgumentNullException(nameof(refreshToken));
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
