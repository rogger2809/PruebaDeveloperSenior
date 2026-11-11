namespace InventoryManagement.Api.Application.DTOs.Products;

public record UpdateProductRequest(int CategoryId, string Name, string Description, decimal Price);
