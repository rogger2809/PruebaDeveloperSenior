using InventoryManagement.Api.Application.Commands.Categories;
using InventoryManagement.Api.Application.DTOs.Categories;
using InventoryManagement.Api.Domain.Entities;
using InventoryManagement.Api.Domain.Interfaces;
using MediatR;

namespace InventoryManagement.Api.Application.Handlers.CommandHandlers.Categories;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Name = request.Request.Name,
            Description = request.Request.Description,
            Activo = true
        };

        var categoryId = await _categoryRepository.CreateAsync(category, cancellationToken);
        return new CreateCategoryResponse(categoryId);
    }
}
