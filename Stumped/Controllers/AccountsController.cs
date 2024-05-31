using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stumped.Commands;

namespace Stumped.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(DepositCommand command)
        {
            var account = await _mediator.Send(command);
            return Ok(account);
        }

        [HttpPost("renew-license")]
        public async Task<IActionResult> RenewLicense(RenewLicenseCommand command)
        {
            var success = await _mediator.Send(command);
            return Ok(success);
        }

        [HttpGet("vehicles")]
        public async Task<IActionResult> GetVehicleList([FromQuery] GetVehicleListQuery query)
        {
            var vehicles = await _mediator.Send(query);
            return Ok(vehicles);
        }
    }

}
