using MediatR;

namespace Tsmp.User.API.Commands
{
    public class CreatePasswordCommand : IRequest<string>
    {
        public string Password { get; set; }
        public string UserId { get; set; }
    }
}
