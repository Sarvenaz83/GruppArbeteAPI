using Infrastructure.DatabaseContext;
using Infrastructure.Repository.AuthorRepository;
using Infrastructure.Repository.BookRepository;
using Infrastructure.Repository.UserRepository;
using Infrastructure.Repository.WalletRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<HarryPotterContext>(options =>
            {
                var connectionString = "Server=localhost,1433;Database=HarryPotter;User Id=sa;Password='Arkemar321@';Encrypt=False;TrustServerCertificate=True;";



                //var connectionString = "Server=(local)\\SQLEXPRESS;Database=HarryPotter;Trusted_Connection=True;TrustServerCertificate=true";
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();

            return services;
        }
    }
}
