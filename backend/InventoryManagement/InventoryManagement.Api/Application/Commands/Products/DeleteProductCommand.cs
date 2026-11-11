using MediatR;

namespace InventoryManagement.Api.Application.Commands.Products;

public record DeleteProductCommand(int ProductId) : IRequest<Unit>;
