using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MisKebap.Business.Abstract;
using MisKebap.Business.Concrete;
using MisKebap.DAL.Context;
using MisKebap.DAL.Entities;

namespace MisKebap.Infrastructure.DependencyInjection
{
    public static class DbInstaller
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MisKebapContext>();

            services.AddScoped<ICategoryImageService, CategoryImageService>();
            services.AddScoped<IMongoDbContext, MongoDbContext>();
            services.Configure<MongoOptions>(configuration.GetSection("MongoOptions"));

            return services;
        }
    }
}
