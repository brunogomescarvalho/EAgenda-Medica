using EAgendaMedica.Aplicacao.ModuloCirurgia;
using EAgendaMedica.Aplicacao.ModuloConsulta;
using EAgendaMedica.Aplicacao.ModuloMedico;
using EAgendaMedica.Dominio;
using EAgendaMedica.Dominio.Copartilhado;
using EAgendaMedica.Dominio.ModuloCirurgia;
using EAgendaMedica.Dominio.ModuloConsulta;
using EAgendaMedica.Infra.Compartilhado;
using EAgendaMedica.Infra.ModuloCirurgia;
using EAgendaMedica.Infra.ModuloConsulta;
using EAgendaMedica.Infra.ModuloMedico;
using eAgendaWebApi.Configs.AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace eAgendaWebApi.Configs
{
    public static class ConfigurarInjecaoDependencia
    {
        public static void InjetarDependencias(this IServiceCollection service, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("SqlServer")!;

            service.AddDbContext<IContextoPersistencia,EAgendaMedicaDBContext >(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(connectionString);
            });

            service.AddTransient<ServicoCirurgia>();
            service.AddTransient<IRepositorioCirurgia, RepositorioCirurgia>();

            service.AddTransient<ServicoConsulta>();
            service.AddTransient<IRepositorioConsulta, RepositorioConsulta>();

            service.AddTransient<ServicoMedico>();
            service.AddTransient<IRepositorioMedico, RepositorioMedico>();

            service.AddTransient<InserirMedicoMappingAction>();
            service.AddTransient<InserirMedicosMappingAction>();


        }
    }
}
