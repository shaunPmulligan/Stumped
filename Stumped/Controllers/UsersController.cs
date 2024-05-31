using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stumped.Commands;

namespace Stumped.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var user = await _mediator.Send(command);
            return Ok(user);
        }
    }

}
