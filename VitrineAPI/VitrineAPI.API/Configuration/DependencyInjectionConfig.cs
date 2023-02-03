using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using VitrineAPI.API.Extensions;
using VitrineAPI.Application.Applications;
using VitrineAPI.Application.Interfaces;
using VitrineAPI.Domain.Core.Interfaces.Repositories;
using VitrineAPI.Domain.Core.Interfaces.Services;
using VitrineAPI.Domain.Core.Notifier;
using VitrineAPI.Domain.Service;
using VitrineAPI.Infrastructure.Data.Repositories;

namespace VitrineAPI.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoApplication, ProdutoApplication>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ICategoriaApplication, CategoriaApplication>();

            services.AddScoped<ISubCategoriaRepository, SubCategoriaRepository>();
            services.AddScoped<ISubCategoriaService, SubCategoriaService>();
            services.AddScoped<ISubCategoriaApplication, SubCategoriaApplication>();

            services.AddScoped<IFabricanteRepository, FabricanteRepository>();
            services.AddScoped<IFabricanteService, FabricanteService>();
            services.AddScoped<IFabricanteApplication, FabricanteApplication>();

            services.AddScoped<IUsuarioApplication, UsuarioApplication>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUser, AspNetUser>();

            services.AddScoped<IEmailApplication, EmailApplication>();

            services.AddScoped<INotificador, Notificador>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }
    }
}