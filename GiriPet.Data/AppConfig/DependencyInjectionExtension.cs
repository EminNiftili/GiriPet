using GiriPet.Data.Repositories.Abstractions;
using GiriPet.Data.Repositories.Implementations;
using GiriPet.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GiriPet.Data.AppConfig
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddGiriPetDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<GiriPetDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("GiriPetConnection")));

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IWalkerRepository, WalkerRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            // Unit of Work
            services.AddScoped<IUnitOfWork, GiriPetUnitOfWork>();

            return services;
        }
    }
}
