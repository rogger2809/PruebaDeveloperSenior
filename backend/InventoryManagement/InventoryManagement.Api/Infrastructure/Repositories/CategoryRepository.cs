using Dapper;
using InventoryManagement.Api.Domain.Entities;
using InventoryManagement.Api.Domain.Interfaces;
using InventoryManagement.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Api.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly InventoryDbContext _dbContext;
    private readonly DapperContext _dapperContext;

    public CategoryRepository(InventoryDbContext dbContext, DapperContext dapperContext)
    {
        _dbContext = dbContext;
        _dapperContext = dapperContext;
    }

    public async Task<int> CreateAsync(Category category, CancellationToken cancellationToken = default)
    {
        using (var connection = _dapperContext.CreateConnection())
        {
            await connection.OpenAsync(cancellationToken);

            var parameters = new DynamicParameters();
            parameters.Add("@Name", category.Name);
            parameters.Add("@Description", category.Description);
            parameters.Add("@Activo", category.Activo);

            var result = await connection.QuerySingleAsync<int>(
                "sp_CreateCategory",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );

            return result;
        }
    }

    public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Categories
            .AsNoTracking()
            .Where(c => c.Activo)
            .ToListAsync(cancellationToken);
    }

    public async Task<Category?> GetByIdAsync(int categoryId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Categories
            .AsNoTracking()
            .Where(c => c.CategoryId == categoryId && c.Activo)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task UpdateAsync(int categoryId, Category category, CancellationToken cancellationToken = default)
    {
        using (var connection = _dapperContext.CreateConnection())
        {
            await connection.OpenAsync(cancellationToken);

            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", categoryId);
            parameters.Add("@Name", category.Name);
            parameters.Add("@Description", category.Description);

            await connection.ExecuteAsync(
                "sp_UpdateCategory",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }

    public async Task DeleteAsync(int categoryId, CancellationToken cancellationToken = default)
    {
        using (var connection = _dapperContext.CreateConnection())
        {
            await connection.OpenAsync(cancellationToken);

            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", categoryId);

            await connection.ExecuteAsync(
                "sp_DeleteCategory",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}
