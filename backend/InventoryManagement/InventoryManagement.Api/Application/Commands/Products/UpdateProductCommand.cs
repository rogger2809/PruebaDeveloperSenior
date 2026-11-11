using MediatR;

namespace InventoryManagement.Api.Application.Commands.Products;

public record UpdateProductCommand(int ProductId, int CategoryId, string Name, string Description, decimal Price) : IRequest<Unit>;
