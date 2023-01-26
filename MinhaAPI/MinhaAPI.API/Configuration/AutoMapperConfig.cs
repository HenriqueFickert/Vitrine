﻿using MinhaAPI.Application.Mappers;

namespace MinhaAPI.API.Configuration
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