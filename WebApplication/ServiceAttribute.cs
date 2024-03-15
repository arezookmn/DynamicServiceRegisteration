
[AttributeUsage(AttributeTargets.Class,AllowMultiple =true)]
public class ServiceAttribute : Attribute
{
    public ServiceLifetime Lifetime { get; }

    public ServiceAttribute(ServiceLifetime lifetime)
    {
        Lifetime = lifetime;
    }
}
