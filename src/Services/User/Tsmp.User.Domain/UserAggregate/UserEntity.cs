using System;

namespace Tsmp.User.Domain
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
