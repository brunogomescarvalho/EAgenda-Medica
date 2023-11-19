using Serilog;
using EAgendaMedica.Infra.Compartilhado;
using EAgendaMedica.ConsoleApp;
using EAgendaMedica.Dominio.ModuloConsulta;
using Microsoft.EntityFrameworkCore;
using EAgendaMedica.Dominio.ModuloMedico;
using EAgendaMedica.Dominio.ModuloCirurgia;

namespace EAgendaMedica.WebApi
{
    public static class AtualizarBancoDadosOrm
    {
        public static async void AtualizarBancoDeDados(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var db = services.GetRequiredService<EAgendaMedicaDBContext>();

                Log.Logger.Information("Atualizando a banco de dados do e-Agenda...");

                var migracaoRealizada = MigradorBancoDadoseAgenda.AtualizarBancoDados(db);

                if (migracaoRealizada)
                {
                    Log.Logger.Information("Banco de dados atualizado");

                    var dataGenerator = services.GetRequiredService<GeradorDeMassaDados>();

                    await dataGenerator.GerarMassaDeDados();              
                }

                else
                    Log.Logger.Information("Nenhuma migração pendente");
            }
        }
    }
}
