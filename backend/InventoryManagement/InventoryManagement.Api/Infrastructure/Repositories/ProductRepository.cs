using Dapper;
using InventoryManagement.Api.Domain.Entities;
using InventoryManagement.Api.Domain.Interfaces;
using InventoryManagement.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Api.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly InventoryDbContext _dbContext;
    private readonly DapperContext _dapperContext;

    public ProductRepository(InventoryDbContext dbContext, DapperContext dapperContext)
    {
        _dbContext = dbContext;
        _dapperContext = dapperContext;
    }

    public async Task<int> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        using (var connection = _dapperContext.CreateConnection())
        {
            await connection.OpenAsync(cancellationToken);

            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", product.CategoryId);
            parameters.Add("@Name", product.Name);
            parameters.Add("@Description", product.Description);
            parameters.Add("@Price", product.Price);
            parameters.Add("@Activo", product.Activo);

            var result = await connection.QuerySingleAsync<int>(
                "sp_CreateProduct",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );

            return result;
        }
    }

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Products
            .AsNoTracking()
            .Where(p => p.Activo)
            .ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(int productId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Products
            .AsNoTracking()
            .Where(p => p.ProductId == productId && p.Activo)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task UpdateAsync(int productId, Product product, CancellationToken cancellationToken = default)
    {
        using (var connection = _dapperContext.CreateConnection())
        {
            await connection.OpenAsync(cancellationToken);

            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", productId);
            parameters.Add("@CategoryId", product.CategoryId);
            parameters.Add("@Name", product.Name);
            parameters.Add("@Description", product.Description);
            parameters.Add("@Price", product.Price);

            await connection.ExecuteAsync(
                "sp_UpdateProduct",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }

    public async Task DeleteAsync(int productId, CancellationToken cancellationToken = default)
    {
        using (var connection = _dapperContext.CreateConnection())
        {
            await connection.OpenAsync(cancellationToken);

            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", productId);

            await connection.ExecuteAsync(
                "sp_DeleteProduct",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}
