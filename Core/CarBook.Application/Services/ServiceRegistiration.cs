using Microsoft.Extensions.DependencyInjection;

namespace CarBook.Application.Services;
public static class ServiceRegistiration
{
    public static void AddApplicationService(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
    }
}
