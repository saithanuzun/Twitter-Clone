using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Twitter.Backend.Application.Mapping;

namespace Twitter.Backend.Application.Extensions;

public  static class Registrations
{
    public static IServiceCollection AddApplicationRegistration(this IServiceCollection serviceCollection)
    {
        var asm = Assembly.GetExecutingAssembly();

        serviceCollection.AddMediatR(asm);

        serviceCollection.AddAutoMapper(asm);
        serviceCollection.AddValidatorsFromAssembly(asm);

        return serviceCollection;
    }
}