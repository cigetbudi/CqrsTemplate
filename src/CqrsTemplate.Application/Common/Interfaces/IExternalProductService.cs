using CqrsTemplate.Application.External.ProductApi.DTOs;

namespace CqrsTemplate.Application.Common.Interfaces;

public interface IExternalProductService
{
    Task<ProductApiResponseDto?> CreateProductAsync(ProductApiRequestDto request, CancellationToken cancellationToken);
}
