using GiriPet.Logic.AutoMapper;
using GiriPet.Data.AppConfig;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using GiriPet.Logic.Abstractions;
using GiriPet.Logic.Services;
using GiriPet.Logic.Validations;
using FluentValidation;

namespace GiriPet.Logic.AppConfig
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddGiriPetLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGiriPetDataServices(configuration);

            // Logic Katmanı Servisleri
            // Auth & Token
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            // User Management
            services.AddScoped<IUserService, UserService>();
            // Walker Management
            services.AddScoped<IWalkerService, WalkerService>();
            // Appointment Management
            services.AddScoped<IAppointmentService, AppointmentService>();
            // Review Management
            services.AddScoped<IReviewService, ReviewService>();
            // Payment (future use)
            services.AddScoped<IPaymentService, PaymentService>();
            // Pet Management
            services.AddScoped<IPetService, PetService>();
            // File Management
            services.AddScoped<IFileService, FileService>();

            // AutoMapper Profili
            services.AddAutoMapper(typeof(GiriPetProfile).Assembly);

            // FluentValidation
            services.AddValidatorsFromAssemblyContaining<UserRegisterDtoValidator>();

            return services;
        }
    }
}
