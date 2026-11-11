using Dapper;
using InventoryManagement.Api.Domain.Entities;
using InventoryManagement.Api.Domain.Interfaces;
using InventoryManagement.Api.Infrastructure.Persistence;

namespace InventoryManagement.Api.Infrastructure.Repositories;

public class InventoryMovementRepository : IInventoryMovementRepository
{
    private readonly DapperContext _dapperContext;

    public InventoryMovementRepository(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<int> CreateAsync(InventoryMovement movement, CancellationToken cancellationToken = default)
    {
        using (var connection = _dapperContext.CreateConnection())
        {
            await connection.OpenAsync(cancellationToken);

            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", movement.ProductId);
            parameters.Add("@MovementType", movement.MovementType);
            parameters.Add("@Quantity", movement.Quantity);
            parameters.Add("@Observations", movement.Observations);

            var result = await connection.QuerySingleAsync<int>(
                "sp_InsertMovInv",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );

            return result;
        }
    }
}
