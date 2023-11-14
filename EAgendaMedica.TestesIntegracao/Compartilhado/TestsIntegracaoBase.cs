using EAgendaMedica.Dominio;
using EAgendaMedica.Dominio.ModuloConsulta;
using EAgendaMedica.Infra.Compartilhado;
using EAgendaMedica.Infra.ModuloConsulta;
using EAgendaMedica.Infra.ModuloMedico;
using FizzWare.NBuilder;
using Microsoft.EntityFrameworkCore;

namespace EAgendaMedica.TestesIntegracao.Compartilhado
{
    public class TestsIntegracaoBase
    {

        protected EAgendaMedicaDBContext dbContext;

        protected IRepositorioConsulta repositorioConsulta;

        protected IRepositorioMedico repositorioMedico;

        public TestsIntegracaoBase()
        {
            this.dbContext = ObterContext();

            this.repositorioConsulta = new RepositorioConsulta(dbContext);

            this.repositorioMedico = new RepositorioMedico(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<Consulta>(async (p) =>
            {
                await repositorioConsulta.Inserir(p);
                await dbContext.SaveChangesAsync();
            });
        }

        public EAgendaMedicaDBContext ObterContext()
        {
            string connectionString = @"Data Source = (LOCALDB)\MSSQLLOCALDB; Initial Catalog = EAgendaMedicaDBTests; Integrated Security = True;";

            var optionsBuilder = new DbContextOptionsBuilder<EAgendaMedicaDBContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new EAgendaMedicaDBContext(optionsBuilder.Options);
        }



        private static void AtualizarBancoDados(DbContext db)
        {
            var migracoesPendentes = db.Database.GetPendingMigrations();

            if (migracoesPendentes.Any())
            {
                db.Database.Migrate();
            }
        }
    }
}