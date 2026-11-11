using InventoryManagement.Api.Domain.Entities;

namespace InventoryManagement.Api.Domain.Interfaces;

public interface IInventoryMovementRepository
{
    Task<int> CreateAsync(InventoryMovement movement, CancellationToken cancellationToken = default);
}
