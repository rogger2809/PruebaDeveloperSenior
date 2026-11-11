using InventoryManagement.Api.Application.DTOs.Products;
using MediatR;

namespace InventoryManagement.Api.Application.Queries.Products;

public record GetProductByIdQuery(int ProductId) : IRequest<ProductResponse?>;
