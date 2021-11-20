using System;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MisKebap.Infrastructure.Middleware;


namespace MisKebap.Infrastructure.DependencyInjection
{
    public static class ValidationInstaller
    {
        public static void AddFluentValidator(this IServiceCollection services)
        {
            //Fluent validation settings
            var assembler = AppDomain.CurrentDomain.Load("MisKebap.Business");
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssembly(assembler));

            //[ApiController] tag prevent default BadRequest return
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
        }

    }
}
