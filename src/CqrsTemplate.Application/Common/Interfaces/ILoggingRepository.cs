using CqrsTemplate.Domain.Entities.Common;

namespace CqrsTemplate.Application.Common.Interfaces;

public interface ILoggingRepository
{
    Task InsertInterfaceLog(CancellationToken cancellationToken, InterfaceLog log);
}

