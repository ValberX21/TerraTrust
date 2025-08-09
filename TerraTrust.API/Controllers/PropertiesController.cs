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
        public async Task<IActionResult> Get(int page = 1, int pageSize = 5)
        {
            var result = await _mediator.Send(new GetAllPropertiesQuery(page, pageSize));
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            if (Id <= 0)
                return BadRequest("Invalid property ID");

            var property = await _mediator.Send(new GetPropertyByIdQuery(Id));
            if (property == null)
                return NotFound();

            return Ok(property);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProperty([FromBody] UpdatePropertyCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(command);
            if (!result)
                return BadRequest("Something wrong in update");

            return Ok("Register updated");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id <= 0)
                return BadRequest("Invalid property ID");

            var result = await _mediator.Send(new DeletePropertyCommand(Id));
            if (!result)

                return NotFound();
            return Ok("Register deleted");
        }


    }
}
