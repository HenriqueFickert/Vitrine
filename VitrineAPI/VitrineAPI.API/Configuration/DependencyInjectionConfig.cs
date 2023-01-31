using Microsoft.Extensions.Options;
using VitrineAPI.API.Extensions;
using VitrineAPI.Application.Applications;
using VitrineAPI.Application.Interfaces;
using VitrineAPI.Domain.Core.Interfaces.Repositories;
using VitrineAPI.Domain.Core.Interfaces.Services;
using VitrineAPI.Domain.Core.Notifier;
using VitrineAPI.Domain.Service;
using VitrineAPI.Infrastructure.Data.Repositories;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace VitrineAPI.API.Configuration
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