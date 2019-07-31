using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tsmp.User.Domain;

namespace Tsmp.User.API
{
    public class SendEmailWhenPasswordResetCreated : INotificationHandler<PasswordResetCreatedEvent>
    {
        private readonly IUserRepository _userRepository;

        public SendEmailWhenPasswordResetCreated(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(PasswordResetCreatedEvent notification, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(x => x.Id.ToLowerInvariant() == notification.UserId.ToLowerInvariant());

            //Send email
        }
    }
}
