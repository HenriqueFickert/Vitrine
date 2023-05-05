using VitrineAPI.Application.Dtos.Smtp;

namespace VitrineAPI.API.Configuration
{
    public static class SmtpConfig
    {
        public static void AddSMTPConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmtpOptions>(configuration.GetSection("SMTPOptions"));
        }
    }
}