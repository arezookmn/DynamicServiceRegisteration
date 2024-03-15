using System;
using System.Reflection;


public static class DynamicServiceRegisterationExtention
{
    public static void AddDynamicServices(this IServiceCollection services, Assembly assembly) 
    { 
        var serviceTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract &&
            t.GetCustomAttributes(typeof(ServiceAttribute), false).Any());

        foreach (var serviceType in serviceTypes)
        {
            var serviceInterface = serviceType.GetInterface($"I{serviceType.Name}");

            var serviceAttribute = (ServiceAttribute)serviceType
                .GetCustomAttributes(typeof(ServiceAttribute), false)
                .First();

            services.Add(new ServiceDescriptor(serviceInterface , serviceType, serviceAttribute.Lifetime));
        }

    }

}
