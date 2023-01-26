using Microsoft.Extensions.Options;
using MinhaAPI.API.Extensions;
using MinhaAPI.Application.Applications;
using MinhaAPI.Application.Interfaces;
using MinhaAPI.Domain.Core.Interfaces.Repositories;
using MinhaAPI.Domain.Core.Interfaces.Services;
using MinhaAPI.Domain.Core.Notifier;
using MinhaAPI.Domain.Service;
using MinhaAPI.Infrastructure.Data.Repositories;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MinhaAPI.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoApplication, ProdutoApplication>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUser, AspNetUser>();

            //services.AddScoped<IEmailApplication, EmailApplication>();

            services.AddScoped<INotificador, Notificador>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }
    }
}