using InventoryManagement.Api.Application.Commands.Categories;
using InventoryManagement.Api.Domain.Interfaces;
using MediatR;

namespace InventoryManagement.Api.Application.Handlers.CommandHandlers.Categories;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoryRepository.DeleteAsync(request.CategoryId, cancellationToken);
        return Unit.Value;
    }
}
