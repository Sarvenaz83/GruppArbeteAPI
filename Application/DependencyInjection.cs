using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(assembly); // Corrected method call

            services.AddValidatorsFromAssembly(assembly); // Corrected method call
            return services;
        }
    }
}
