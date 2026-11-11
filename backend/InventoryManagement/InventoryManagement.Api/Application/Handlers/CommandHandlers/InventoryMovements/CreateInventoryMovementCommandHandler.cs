using InventoryManagement.Api.Application.Commands.InventoryMovements;
using InventoryManagement.Api.Application.DTOs.InventoryMovements;
using InventoryManagement.Api.Domain.Entities;
using InventoryManagement.Api.Domain.Interfaces;
using MediatR;

namespace InventoryManagement.Api.Application.Handlers.CommandHandlers.InventoryMovements;

public class CreateInventoryMovementCommandHandler : IRequestHandler<CreateInventoryMovementCommand, CreateInventoryMovementResponse>
{
    private readonly IInventoryMovementRepository _movementRepository;

    public CreateInventoryMovementCommandHandler(IInventoryMovementRepository movementRepository)
    {
        _movementRepository = movementRepository;
    }

    public async Task<CreateInventoryMovementResponse> Handle(CreateInventoryMovementCommand request, CancellationToken cancellationToken)
    {
        var movement = new InventoryMovement
        {
            ProductId = request.Request.ProductId,
            MovementType = request.Request.MovementType,
            Quantity = request.Request.Quantity,
            Observations = request.Request.Observations
        };

        await _movementRepository.CreateAsync(movement, cancellationToken);
        return new CreateInventoryMovementResponse("Inventory movement registered successfully");
    }
}
