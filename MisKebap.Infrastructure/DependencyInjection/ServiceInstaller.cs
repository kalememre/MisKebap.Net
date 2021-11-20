using System;
using Microsoft.Extensions.DependencyInjection;
using MisKebap.Business.Abstract;
using MisKebap.Business.Concrete;
using MisKebap.DAL.Context;
using MisKebap.DAL.LoginSecurity.JWT;

namespace MisKebap.Infrastructure.DependencyInjection
{
    public static class ServiceInstaller
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<ITokenHelper, TokenHelper>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<INBHService, NBHService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOtherService, OtherService>();
            services.AddScoped<IProductService, ProductService>();



            return services;
        }
    }
}
