using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace eAgendaWebApi.Configs
{
    public static class SwaggerConfigExtension
    {
        public static void ConfigurarSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(x =>
            {
                x.MapType<TimeSpan>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("00:00")
                });

                x.MapType<DateTime>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("01-20-2023")
                });
            });
        }
    }
}
