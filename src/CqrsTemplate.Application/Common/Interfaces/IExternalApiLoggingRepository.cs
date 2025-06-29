using CqrsTemplate.Domain.Entities.Common;

namespace CqrsTemplate.Application.Common.Interfaces;

public interface IExternalApiLoggingRepository
{
    Task InsertExternalApiLog(CancellationToken cancellationToken, ExternalApiLog log);
}
