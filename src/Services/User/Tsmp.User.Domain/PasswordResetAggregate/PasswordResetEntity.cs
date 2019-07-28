using System;
using System.Collections.Generic;
using System.Text;

namespace Tsmp.User.Domain.PasswordResetAggregate
{
    public class PasswordResetEntity
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
