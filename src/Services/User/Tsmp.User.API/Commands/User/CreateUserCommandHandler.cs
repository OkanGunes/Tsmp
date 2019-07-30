using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tsmp.User.Domain;

namespace Tsmp.User.API.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public CreateUserCommandHandler(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = new UserEntity
            {
                Id = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.UtcNow,
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname
            };

            await _userRepository.CreateUserAsync(userEntity, cancellationToken);

            await _mediator.Send(new CreatePasswordCommand
            {
                Password = request.Password,
                UserId = userEntity.Id
            }, cancellationToken);

            return userEntity.Id;
        }
    }
}
