using System;
using System.Collections.Generic;
using System.Text;

namespace Tsmp.User.Domain.PasswordAggregate
{
    public class PasswordEntity
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Hash { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
