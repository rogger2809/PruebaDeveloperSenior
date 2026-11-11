namespace InventoryManagement.Api.Application.DTOs.Products;

public record ProductResponse(int ProductId, int CategoryId, string CategoryName, string Name, string Description, decimal Price, int Stock);
