using Application.Queries.UserQueries.LoginUser;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(assembly); // Corrected method call

            services.AddScoped<ITokenGenerator, TokenGenerator>();

            services.AddValidatorsFromAssembly(assembly); // Corrected method call

            return services;
        }
    }
}
