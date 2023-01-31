using VitrineAPI.Application.Mappers;

namespace VitrineAPI.API.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
               typeof(ProdutoMappingProfile));
        }
    }
}