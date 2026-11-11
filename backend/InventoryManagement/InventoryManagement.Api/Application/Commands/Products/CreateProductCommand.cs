using InventoryManagement.Api.Application.DTOs.Products;
using MediatR;

namespace InventoryManagement.Api.Application.Commands.Products;

public record CreateProductCommand(CreateProductRequest Request) : IRequest<CreateProductResponse>;
