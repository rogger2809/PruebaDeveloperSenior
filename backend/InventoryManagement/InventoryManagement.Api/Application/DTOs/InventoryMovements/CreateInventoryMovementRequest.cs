namespace InventoryManagement.Api.Application.DTOs.InventoryMovements;

public record CreateInventoryMovementRequest(int ProductId, string MovementType, int Quantity, string Observations);
