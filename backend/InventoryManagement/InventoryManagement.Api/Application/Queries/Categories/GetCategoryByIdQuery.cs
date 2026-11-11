using InventoryManagement.Api.Application.DTOs.Categories;
using MediatR;

namespace InventoryManagement.Api.Application.Queries.Categories;

public record GetCategoryByIdQuery(int CategoryId) : IRequest<CategoryResponse?>;
