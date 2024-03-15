
public interface IService
{
    public Guid ServiceId { get; init; }
    void LogLifetimeEvent(string message);
}

public interface IScopedService : IService
{

}
public interface ISingletonService : IService
{
}

public interface ITransientService : IService
{
}
