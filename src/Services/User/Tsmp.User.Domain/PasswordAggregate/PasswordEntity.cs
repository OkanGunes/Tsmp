using System;

namespace Tsmp.User.Domain
{
    public class PasswordEntity
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Hash { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
