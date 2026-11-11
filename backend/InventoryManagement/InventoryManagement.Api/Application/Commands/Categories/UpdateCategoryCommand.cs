using MediatR;

namespace InventoryManagement.Api.Application.Commands.Categories;

public record UpdateCategoryCommand(int CategoryId, string Name, string Description) : IRequest<Unit>;
