namespace CqrsTemplate.Infrastructure.Common.ExternalApiLogging;

public interface INamedClientFactory
{
    string ClientName { get; }
}

public class NamedClientFactory(string clientName) : INamedClientFactory
{
    public string ClientName { get; } = clientName;
}
