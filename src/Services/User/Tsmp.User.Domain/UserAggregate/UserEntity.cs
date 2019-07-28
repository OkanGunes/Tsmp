using System;
using System.Collections.Generic;
using System.Text;

namespace Tsmp.User.Domain.UserAggregate
{
    public class UserEntity 
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
