using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MinhaAPI.Identity.Data;
using MinhaAPI.Identity.Entities;
using MinhaAPI.Identity.Extensions;

namespace MinhaAPI.API.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityDataContext>(options => options.UseSqlServer(configuration.GetConnectionString("Connection")));

            services.AddDefaultIdentity<Usuario>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddErrorDescriber<IdentityLocalization>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;

                options.SignIn.RequireConfirmedEmail = true;
            });

            return services;
        }
    }
}