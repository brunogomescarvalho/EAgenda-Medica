using EAgendaMedica.Dominio;
using EAgendaMedica.Dominio.ModuloCirurgia;
using EAgendaMedica.Dominio.ModuloConsulta;
using EAgendaMedica.Infra.Compartilhado;
using EAgendaMedica.Infra.ModuloCirurgia;
using EAgendaMedica.Infra.ModuloConsulta;
using EAgendaMedica.Infra.ModuloMedico;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace EAgendaMedica.TestesIntegracao.Compartilhado
{
    [TestClass]
    public class TestsIntegracaoBase
    {

        protected EAgendaMedicaDBContext dbContext;

        protected IRepositorioConsulta repositorioConsulta;

        protected IRepositorioCirurgia repositorioCirurgia;

        protected IRepositorioMedico repositorioMedico;

        public TestsIntegracaoBase()
        {
            this.dbContext = ObterContext();

            this.repositorioConsulta = new RepositorioConsulta(dbContext);

            this.repositorioMedico = new RepositorioMedico(dbContext);

            this.repositorioCirurgia = new RepositorioCirurgia(dbContext);

        }

        public EAgendaMedicaDBContext ObterContext()
        {
            string[] args = new string[] { "Testing" };

            var dbContextFactory = new EAgendaMedicaContextFactory();

            var dbContext = dbContextFactory.CreateDbContext(args);

            AtualizarBancoDados(dbContext);

            return dbContext;

        }

        private static void AtualizarBancoDados(DbContext db)
        {
            var migracoesPendentes = db.Database.GetPendingMigrations();

            if (migracoesPendentes.Any())
            {
                db.Database.Migrate();
            }
        }


        [TestMethod]
        public async Task AoCriarOBancoDeDados_DeveGerarDoisCadastros()
        {       
            var medicos = await repositorioMedico.SelecionarTodos();

            medicos.Count.Should().Be(2);
        }
    }
}