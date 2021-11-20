using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MisKebap.Infrastructure.DependencyInjection;

namespace MisKebap.WebAPI.ServiceInstaller
{
    public class InfrastructureInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddFluentValidator();
            services.AddService();
            services.AddPersistence(configuration);
            services.AddJwtAuthentication(configuration);

        }
    }
}
