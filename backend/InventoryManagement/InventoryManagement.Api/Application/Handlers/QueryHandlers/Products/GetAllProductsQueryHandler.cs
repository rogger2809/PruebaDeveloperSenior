using InventoryManagement.Api.Application.DTOs.Products;
using InventoryManagement.Api.Application.Queries.Products;
using InventoryManagement.Api.Domain.Interfaces;
using MediatR;

namespace InventoryManagement.Api.Application.Handlers.QueryHandlers.Products;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync(cancellationToken);
        return products.Select(p => new ProductResponse(
            p.ProductId,
            p.CategoryId,
            string.Empty,
            p.Name,
            p.Description,
            p.Price,
            p.StockActual
        ));
    }
}
