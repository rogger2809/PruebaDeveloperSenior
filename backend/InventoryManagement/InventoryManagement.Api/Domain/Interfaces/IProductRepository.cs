using InventoryManagement.Api.Domain.Entities;

namespace InventoryManagement.Api.Domain.Interfaces;

public interface IProductRepository
{
    Task<int> CreateAsync(Product product, CancellationToken cancellationToken = default);
    Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Product?> GetByIdAsync(int productId, CancellationToken cancellationToken = default);
    Task UpdateAsync(int productId, Product product, CancellationToken cancellationToken = default);
    Task DeleteAsync(int productId, CancellationToken cancellationToken = default);
}
