using AdvertisementApp.Bussniess.Interfaces;
using AdvertisementApp.Bussniess.Services;
using AdvertisementApp.Bussniess.ValidationRules.FluentValidations.Advertisement;
using AdvertisementApp.Bussniess.ValidationRules.FluentValidations.AdvertisementAppUser;
using AdvertisementApp.Bussniess.ValidationRules.FluentValidations.AppUser;
using AdvertisementApp.Bussniess.ValidationRules.FluentValidations.Gender;
using AdvertisementApp.Bussniess.ValidationRules.FluentValidations.PrpvidedService;
using AdvertisementApp.DataAccess.Context;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdvertisementApp.Bussniess.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });

            //AUTOMAPPER DEPENDENCY INJECTİON  OTOMATIK AYAR
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //VEYA BÖYLE KULLANILABILIR
            //var mapperConfiguration = new MapperConfiguration(opt =>
            //{
            //    //opt.AddProfile();
            //});
            //var mapper = mapperConfiguration.CreateMapper();
            //services.AddSingleton(mapper);

            services.AddScoped<IUow, Uow>();


            // Fluent Validation
            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();
            //------------------
            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();

            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();

            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();


            services.AddTransient<IValidator<AdvertisementAppUserCreateDto>, AdvertisementAppUserCreateDtoValidator>();


            // Fluent Validation

            //IService
            services.AddScoped<IProvidedServiceService, ProvidedServiceService>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IAdvertisementAppUserService, AdvertisementAppUserService>();

            //IService

        }
    }
}
