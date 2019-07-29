using System;

namespace Tsmp.User.Domain
{
    public class PasswordResetEntity
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
