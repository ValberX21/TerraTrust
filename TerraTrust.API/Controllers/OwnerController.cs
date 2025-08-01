using MediatR;
using Microsoft.AspNetCore.Mvc;
using TerraTrust.Business.Commands;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TerraTrust.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : Controller
    {
        private readonly IMediator _mediator;

        public OwnerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateOwner")]
        public async Task<IActionResult> Create([FromBody] CreateOwnerCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _mediator.Send(command);
            return Created($"/api/owner/{id}", new { id });
        }
    }
}
