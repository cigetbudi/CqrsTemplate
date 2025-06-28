using CqrsTemplate.Application.Common.Interfaces;
using CqrsTemplate.Domain.Entities;
using Dapper;

namespace CqrsTemplate.Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DbConnectionFactory _dbConnectionFactory;

    public ProductRepository(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        const string sql = """
            INSERT INTO products (id, name, created_at)
            VALUES (@Id, @Name, @CreatedAt)
            ON CONFLICT (id) DO NOTHING;
            """;

        await using var connection = _dbConnectionFactory.CreateConnectionDBCoba();
        await connection.ExecuteAsync(new CommandDefinition(sql, product, cancellationToken: cancellationToken));
    }
}
