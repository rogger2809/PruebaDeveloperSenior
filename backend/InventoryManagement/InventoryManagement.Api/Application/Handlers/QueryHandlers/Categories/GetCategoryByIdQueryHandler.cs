using InventoryManagement.Api.Application.DTOs.Categories;
using InventoryManagement.Api.Application.Queries.Categories;
using InventoryManagement.Api.Domain.Interfaces;
using MediatR;

namespace InventoryManagement.Api.Application.Handlers.QueryHandlers.Categories;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryResponse?>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryResponse?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);
        if (category is null)
            return null;

        return new CategoryResponse(category.CategoryId, category.Name, category.Description);
    }
}
