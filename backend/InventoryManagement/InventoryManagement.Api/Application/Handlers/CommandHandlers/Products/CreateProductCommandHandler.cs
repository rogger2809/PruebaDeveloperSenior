using InventoryManagement.Api.Application.Commands.Products;
using InventoryManagement.Api.Application.DTOs.Products;
using InventoryManagement.Api.Domain.Entities;
using InventoryManagement.Api.Domain.Interfaces;
using MediatR;

namespace InventoryManagement.Api.Application.Handlers.CommandHandlers.Products;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            CategoryId = request.Request.CategoryId,
            Name = request.Request.Name,
            Description = request.Request.Description,
            Price = request.Request.Price,
            StockActual = 0,
            Activo = true
        };

        var productId = await _productRepository.CreateAsync(product, cancellationToken);
        return new CreateProductResponse(productId);
    }
}
