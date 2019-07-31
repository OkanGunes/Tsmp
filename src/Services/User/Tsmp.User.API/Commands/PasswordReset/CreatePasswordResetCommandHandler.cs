using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tsmp.User.Domain;

namespace Tsmp.User.API.Commands
{
    public class CreatePasswordResetCommandHandler : IRequestHandler<CreatePasswordResetCommand, string>
    {
        private readonly IPasswordResetRepository _passwordResetRepository;
        private readonly IUserRepository _userRepository;

        public CreatePasswordResetCommandHandler(IPasswordResetRepository passwordResetRepository, IUserRepository userRepository)
        {
            _passwordResetRepository = passwordResetRepository;
            _userRepository = userRepository;
        }

        public async Task<string> Handle(CreatePasswordResetCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(x => x.Email.ToLowerInvariant() == request.Email.ToLowerInvariant());

            var passwordResetEntity = new PasswordResetEntity
            {
                CreatedDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow.AddMinutes(30),
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id
            };

            await _passwordResetRepository.CreatePasswordResetAsync(passwordResetEntity, cancellationToken);

            // Send E-Mail But Don't Directly, Send a PasswordResetEntityCreated Event

            return passwordResetEntity.Id;
        }
    }
}
