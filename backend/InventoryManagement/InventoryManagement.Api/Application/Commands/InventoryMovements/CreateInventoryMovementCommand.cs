using InventoryManagement.Api.Application.DTOs.InventoryMovements;
using MediatR;

namespace InventoryManagement.Api.Application.Commands.InventoryMovements;

public record CreateInventoryMovementCommand(CreateInventoryMovementRequest Request) : IRequest<CreateInventoryMovementResponse>;
