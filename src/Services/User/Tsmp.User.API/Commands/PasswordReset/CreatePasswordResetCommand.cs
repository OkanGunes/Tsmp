using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tsmp.User.API.Commands
{
    public class CreatePasswordResetCommand : IRequest<string>
    {
        public string Email { get; set; }
    }
}
