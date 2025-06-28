using CqrsTemplate.Domain.Entities;

namespace CqrsTemplate.Application.Common.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product, CancellationToken cancellationToken);
}