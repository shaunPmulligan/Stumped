using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stumped.Commands;

namespace Stumped.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuotesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuoteCommand command)
        {
            var quote = await _mediator.Send(command);
            return Ok(quote);
        }
    }

}
