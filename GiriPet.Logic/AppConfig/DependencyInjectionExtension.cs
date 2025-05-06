using GiriPet.Logic.AutoMapper;
using GiriPet.Data.AppConfig;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using GiriPet.Logic.Abstractions;
using GiriPet.Logic.Services;
using GiriPet.Logic.Validations;
using FluentValidation;
using GiriPet.Logic.Models;

namespace GiriPet.Logic.AppConfig
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddGiriPetLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGiriPetDataServices(configuration);

            var localizationSection = configuration.GetSection("Localizations");
            var locSettings = LocalizationSettings.FromConfiguration(localizationSection);
            var locService = new LocalizationService(locSettings);
            services.AddSingleton<ILocalizationService>(locService);

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
            // Image Management
            services.AddScoped<IImageService, ImageService>();

            // Logger Profili
            var giriLogSection = configuration.GetSection("GiriLog");
            var giriLogSettings = GiriLogSettings.FromConfiguration(giriLogSection);
            services.AddSingleton<IGiriLogger, GiriLogger>();

            // AutoMapper Profili
            services.AddAutoMapper(typeof(GiriPetProfile).Assembly);

            // FluentValidation
            services.AddValidatorsFromAssemblyContaining<UserRegisterDtoValidator>();

            return services;
        }
    }
}
