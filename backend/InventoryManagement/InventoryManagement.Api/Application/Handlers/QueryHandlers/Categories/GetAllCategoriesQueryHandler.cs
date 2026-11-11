using InventoryManagement.Api.Application.DTOs.Categories;
using InventoryManagement.Api.Application.Queries.Categories;
using InventoryManagement.Api.Domain.Interfaces;
using MediatR;

namespace InventoryManagement.Api.Application.Handlers.QueryHandlers.Categories;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync(cancellationToken);
        return categories.Select(c => new CategoryResponse(c.CategoryId, c.Name, c.Description));
    }
}
