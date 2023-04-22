using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product.API.Helpers;
using Product.API.Infrastructure.Context;
using Product.API.Mappers;
using Product.API.Repositories;
using Product.API.Services;
using Product.API.Settings;

namespace Product.API.Extensions;

public static class IOC
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<AuthService>();
        services.AddScoped<ProductService>();
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ProductRepository>();
        return services;
    }

    public static IServiceCollection AddHelpers(this IServiceCollection services)
    {
        services.AddSingleton<SecurityHelper>();
        return services;
    }

    public static IServiceCollection AddSqlite(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ProductDbContext>(options => options
            .UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }

    public static IServiceCollection AddConfigurationSettings(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
        return services;
    }
    
    public static IServiceCollection AddAutomapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IOC));

        MapperConfiguration mapperConfig = new(mc =>
        {
            mc.AddProfile(new ProductProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}