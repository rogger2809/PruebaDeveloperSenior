using InventoryManagement.Api.Application.Commands.InventoryMovements;
using InventoryManagement.Api.Application.DTOs.InventoryMovements;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryMovementsController : ControllerBase
{
    private readonly IMediator _mediator;

    public InventoryMovementsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("movements")]
    public async Task<ActionResult<CreateInventoryMovementResponse>> Create(
        [FromBody] CreateInventoryMovementRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateInventoryMovementCommand(request);
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
