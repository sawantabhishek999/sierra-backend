using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SierraInteractiveEvaluation.Models.AutoMapperProfiles;
using SierraInteractiveEvaluation.Services;
using SierraInteractiveEvaluation.Utilities;

namespace SierraInteractiveEvaluation.API
{
    public static class Extensions
    {
        public static IServiceCollection RegisterServices(
          this IServiceCollection services)
        {
            services.AddScoped<ILeadsService, LeadsService>();
            services.AddScoped<ILogger, Logger>();
            return services;
        }
    }

    public static class AutoMapperServiceExtension
    {
        public static IServiceCollection AddAutoMapper(
            this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new LeadsMapperProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
