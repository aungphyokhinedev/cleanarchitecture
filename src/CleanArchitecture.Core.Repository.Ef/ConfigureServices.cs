using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Core.Domain;
using CleanArchitecture.Core.Service;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Core.Repository.Ef;


public static class ConfigureServices
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
                    
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
       
        services.AddTransient<IDateTimeService, DateTimeService>();
        services.AddTransient<ICurrentUserService, CurrentUserService>();

        return services;
    }
}