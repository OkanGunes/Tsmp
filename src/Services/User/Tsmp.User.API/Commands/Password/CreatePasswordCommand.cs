using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tsmp.User.API.Commands
{
    public class CreatePasswordCommand : IRequest<string>
    {
        public string Password { get; set; }
        public string UserId { get; set; }
    }
}
