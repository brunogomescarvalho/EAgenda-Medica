using eAgendaWebApi.Configs.AutoMapper;
using eAgendaWebApi.Configs;
using Microsoft.AspNetCore.Mvc;
using EAgendaMedica.WebApi.Configs;

namespace EAgendaMedica.WebApi
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.ConfigurarCors();

            builder.Services.InjetarDependencias(builder.Configuration);

            builder.Services.ConfigurarLoggin(builder.Logging);

            builder.Services.ConfigurarAutoMapper();

            builder.Services.ConfigurarControladores();

            builder.Services.ConfigurarSwagger();

            builder.Services.Configure<ApiBehaviorOptions>(config =>
            {
                config.SuppressModelStateInvalidFilter = true;
            });

            var app = builder.Build();

            app.AtualizarBancoDeDados();

            app.UseMiddleware<ManipuladorExcessoes>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("Desenvolvimento");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();



        }
    }
}