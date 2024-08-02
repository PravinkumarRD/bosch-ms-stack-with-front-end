using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bosch.Events.UseCases
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddUseCaseServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
