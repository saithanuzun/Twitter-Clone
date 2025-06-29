using Microsoft.Extensions.DependencyInjection;

namespace Twitter.Backend.Application.Extensions;

public  static class Registrations
{
    public static IServiceCollection AddApplicationRegistration(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}