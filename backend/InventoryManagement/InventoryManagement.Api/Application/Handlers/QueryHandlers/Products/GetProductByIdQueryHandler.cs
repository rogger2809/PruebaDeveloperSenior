using InventoryManagement.Api.Application.DTOs.Products;
using InventoryManagement.Api.Application.Queries.Products;
using InventoryManagement.Api.Domain.Interfaces;
using MediatR;

namespace InventoryManagement.Api.Application.Handlers.QueryHandlers.Products;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResponse?>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductResponse?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);
        if (product is null)
            return null;

        return new ProductResponse(
            product.ProductId,
            product.CategoryId,
            string.Empty,
            product.Name,
            product.Description,
            product.Price,
            product.StockActual
        );
    }
}
