namespace InventoryManagement.Api.Application.DTOs.Products;

public record CreateProductRequest(int CategoryId, string Name, string Description, decimal Price);
