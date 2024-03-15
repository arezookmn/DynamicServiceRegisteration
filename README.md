# Dynamic Service Registration

## Introduction
DynamicServiceRegistration is a demonstration project showcasing how to register services dynamically in a .NET Core application using attributes to define the lifetime of each service. This approach provides flexibility and ease of management when dealing with a large number of services.

## Usage

### Defining Service Lifetime
To define the lifetime of a service, you can use the `Service` attribute. This attribute has one property, `Lifetime`, which specifies the lifetime of the service.

Example:
```csharp
[Service(ServiceLifetime.Transient)]
public class MyTransientService : IService
{
    // Implementation
}
```

### Adding Services to Service Collection
In your `Program.cs` or `Startup.cs`, use the `AddDynamicServices` extension method to add dynamically registered services to the service collection.

Example:
```csharp
builder.Services.AddDynamicServices(Assembly.GetExecutingAssembly());
```

This method utilizes reflection to gather all services that have the `Service` attribute and adds them to the service collection based on their specified lifetime.

### Controller Usage
You can inject dynamically registered services into your controllers for testing purposes or other application needs.

Example:
```csharp
public class TestController : ControllerBase
{
    private readonly ITransientService _transientService;

    public TestController(ITransientService transientService)
    {
        _transientService = transientService;
    }

    // Controller actions
}
```

## Conclusion
Dynamic service registration simplifies the process of managing services in your application by allowing you to define their lifetimes using attributes and automatically adding them to the service collection. This approach promotes cleaner code and easier maintenance.
