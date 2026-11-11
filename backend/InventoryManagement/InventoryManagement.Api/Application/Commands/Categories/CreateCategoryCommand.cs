using InventoryManagement.Api.Application.DTOs.Categories;
using MediatR;

namespace InventoryManagement.Api.Application.Commands.Categories;

public record CreateCategoryCommand(CreateCategoryRequest Request) : IRequest<CreateCategoryResponse>;
