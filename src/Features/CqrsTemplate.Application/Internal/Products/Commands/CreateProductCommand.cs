using CqrsTemplate.Application.Common.Wrappers;
using CqrsTemplate.Application.Internal.Products.DTOs;
using MediatR;

namespace CqrsTemplate.Application.Products.Commands.CreateProduct;

public class CreateProductCommand(CreateProductRequestDto createProductData) : IRequest<ApiResponse<CreateProductResponseDto>>
{
    public CreateProductRequestDto CreateProductData { get; set; } = createProductData;
}
