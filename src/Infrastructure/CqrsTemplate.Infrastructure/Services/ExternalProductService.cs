
using System.Net.Http.Json;
using CqrsTemplate.Application.Common.Interfaces;
using CqrsTemplate.Application.External.ProductApi.DTOs;
using Microsoft.Extensions.Configuration;

namespace CqrsTemplate.Infrastructure.Services;

public class ExternalProductService : IExternalProductService
{
    private readonly HttpClient _httpClient;
    private readonly string _externalApiUrl;
    
    public ExternalProductService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClient = httpClientFactory.CreateClient("ExternalApi");
        _externalApiUrl = configuration["ExternalApiService:Url"]
            ?? throw new InvalidOperationException("External API URL not configured.");
    }

    public async Task<ProductApiResponseDto?> CreateProductAsync(ProductApiRequestDto request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(_externalApiUrl, request, cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<ProductApiResponseDto>(cancellationToken: cancellationToken);
    }
}