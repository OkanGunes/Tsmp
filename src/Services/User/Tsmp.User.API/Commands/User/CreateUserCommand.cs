using MediatR;

namespace Tsmp.User.API.Commands
{
    public class CreateUserCommand : IRequest<string>
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Password { get; set; }
    }
}
