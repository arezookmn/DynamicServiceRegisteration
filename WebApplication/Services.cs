using Microsoft.Extensions.Logging;



[Service(ServiceLifetime.Transient)]
public class TransientService(ILogger<TransientService> logger) : ITransientService
{
    public Guid ServiceId { get; init; } = Guid.NewGuid();

    public void LogLifetimeEvent(string message)
    {
        logger.LogInformation($"Transient Service {ServiceId}:  {message}");
    }
}
[Service(ServiceLifetime.Scoped)]
public class ScopedService(ILogger<ScopedService> logger) : IScopedService
{
    public Guid ServiceId { get; init; } = Guid.NewGuid();

    public void LogLifetimeEvent(string message)
    {
        logger.LogInformation($"Scoped Service {ServiceId}:  {message}");
    }
}

[Service(ServiceLifetime.Singleton)]
public class SingletonService(ILogger<SingletonService> logger) : ISingletonService
{
    public Guid ServiceId { get; init; } = Guid.NewGuid();

    public void LogLifetimeEvent(string message)
    {
        logger.LogInformation($"Singleton Service {ServiceId} :  {message}");
    }
}

