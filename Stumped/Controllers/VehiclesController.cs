using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stumped.Commands;

namespace Stumped.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehiclesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddVehicleCommand command)
        {
            var vehicle = await _mediator.Send(command);
            return Ok(vehicle);
        }
    }

}
