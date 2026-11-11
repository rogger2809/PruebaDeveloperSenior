using InventoryManagement.Api.Domain.Entities;

namespace InventoryManagement.Api.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<int> CreateAsync(Category category, CancellationToken cancellationToken = default);
    Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Category?> GetByIdAsync(int categoryId, CancellationToken cancellationToken = default);
    Task UpdateAsync(int categoryId, Category category, CancellationToken cancellationToken = default);
    Task DeleteAsync(int categoryId, CancellationToken cancellationToken = default);
}
