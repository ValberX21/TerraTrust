using MediatR;
using Microsoft.AspNetCore.Mvc;
using TerraTrust.Business.Commands;
using TerraTrust.Business.Queries;

namespace TerraTrust.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PropertiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePropertyCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _mediator.Send(command);
            return Created($"/api/properties/{id}", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllPropertiesQuery());
            return Ok(result);
        }
    }
}
