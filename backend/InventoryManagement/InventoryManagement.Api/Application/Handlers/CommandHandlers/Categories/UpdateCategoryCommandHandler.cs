using InventoryManagement.Api.Application.Commands.Categories;
using InventoryManagement.Api.Domain.Entities;
using InventoryManagement.Api.Domain.Interfaces;
using MediatR;

namespace InventoryManagement.Api.Application.Handlers.CommandHandlers.Categories;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            CategoryId = request.CategoryId,
            Name = request.Name,
            Description = request.Description,
            Activo = true
        };

        await _categoryRepository.UpdateAsync(request.CategoryId, category, cancellationToken);
        return Unit.Value;
    }
}
