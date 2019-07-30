using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tsmp.User.API.Commands;

namespace Tsmp.User.API.Controllers
{
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult> PostUser([FromBody]CreateUserCommand createUserCommand)
        {
            return Ok(await _mediator.Send(createUserCommand));
        }
    }
}
