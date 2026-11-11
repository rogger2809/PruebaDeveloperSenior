using MediatR;

namespace InventoryManagement.Api.Application.Commands.Categories;

public record DeleteCategoryCommand(int CategoryId) : IRequest<Unit>;
