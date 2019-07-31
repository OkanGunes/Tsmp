using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tsmp.User.API
{
    public class PasswordResetCreatedEvent : INotification
    {
        public string PasswordResetId { get; set; }

        public string UserId { get; set; }
    }
}
