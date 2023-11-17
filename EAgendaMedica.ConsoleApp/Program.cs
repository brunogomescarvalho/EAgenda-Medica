using EAgendaMedica.Dominio.ModuloCirurgia;
using EAgendaMedica.Infra.Compartilhado;
using EAgendaMedica.Infra.ModuloCirurgia;
using Microsoft.EntityFrameworkCore;
using EAgendaMedica.Infra.ModuloConsulta;
using EAgendaMedica.Infra.ModuloMedico;
using EAgendaMedica.Dominio.ModuloConsulta;

namespace EAgendaMedica.ConsoleApp
{
    public partial class Program
    {
        private static EAgendaMedicaDBContext dbContext = null!;
        private static RepositorioConsulta resConsulta = null!;
        private static RepositorioCirurgia resCirurgia = null!;
        private static RepositorioMedico resMed = null!;

        static async Task Main(string[] args)
        {
            dbContext = IniciarContexto();

            resConsulta = new RepositorioConsulta(dbContext);
            resCirurgia = new RepositorioCirurgia(dbContext);
            resMed = new RepositorioMedico(dbContext);

          //  await GerarMassaDeDados();

            await MostrarDados();
        }

        private static async Task GerarMassaDeDados()
        {
            var gerador = new GeradorDeMassaDados(dbContext);

            await gerador.GerarMassaDeDados();
        }

        private static async Task MostrarDados()
        {
            Console.Clear();

            await ListarCirurgias();

            BuscarUmMedicoPorCrm();

            await ListarOsMedicos();

            await ListarConsultas();

            ListarMedicosOrdemAtendimento();
        }

        private static EAgendaMedicaDBContext IniciarContexto()
        {
            var optionsBuilder = new DbContextOptionsBuilder<EAgendaMedicaDBContext>();

            optionsBuilder.UseSqlServer(@"Data Source=(LOCALDB)\MSSQLLOCALDB;Initial Catalog=EAgendaMedicaDB;Integrated Security=True");

            var dbContext = new EAgendaMedicaDBContext(optionsBuilder.Options);

            AtualizarBancoDados(dbContext);

            return dbContext;
        }



        private static void AtualizarBancoDados(DbContext db)
        {
            var migracoesPendentes = db.Database.GetPendingMigrations();

            if (migracoesPendentes.Any())
            {
                db.Database.Migrate();

                Console.Clear();
                Console.WriteLine("Atualizado...");

            }
        }


        private static void BuscarUmMedicoPorCrm()
        {
            Console.WriteLine("\n---Buscar Médico Por Crm---");

            var med = resMed.SelecionarPorCRM("1230-SC").Result;

            if (med != null)
                Console.WriteLine(med + " " + "nr atividades:" + med.TodasAtividades().Count);

        }

        private static async Task ListarOsMedicos()
        {
            Console.WriteLine("\n---Listagem de Medicos ---");
            var medicos = await resMed.SelecionarTodos();

            if (medicos.Any())
            {
                foreach (var item in medicos)
                {
                    Console.WriteLine(item + " " + "nr atividades:" + item.TodasAtividades().Count);
                }
            }

            else
                Console.WriteLine("fail...");
        }

        private static async Task ListarCirurgias()
        {
            Console.WriteLine("\n---Listagem Cirurgias---");
            var lista = await resCirurgia.SelecionarTodos();

            if (lista.Any())
            {
                foreach (var item in lista)
                {
                    Console.WriteLine(new Cirurgia(item.Id, item.DataInicio, item.HoraInicio, item.DuracaoEmMinutos, item.Medicos));
                }
            }

            else
                Console.WriteLine("fail...");
        }

        private static async Task ListarConsultas()
        {
            Console.WriteLine("\n---Listagem Consultas---");
            var lista = await resConsulta.SelecionarTodos();

            if (lista.Any())
            {
                foreach (Consulta item in lista)
                {
                    Console.WriteLine(new Consulta(item.Id, item.DataInicio, item.HoraInicio, item.DuracaoEmMinutos, item.Medico));
                }
            }

            else
                Console.WriteLine("fail...");
        }

        public static void ListarMedicosOrdemAtendimento()
        {
            Console.WriteLine("\n---Listagem Médicos Ordem Atendimento---");

            var lista = resMed.SelecionarComMaisAtendimentosNoPeriodo(DateTime.Now.AddDays(-5), DateTime.Now.AddDays(5));

            if (lista.Any())
            {
                foreach (var item in lista)
                {
                    Console.WriteLine(item + " " + item.HorasTrabalhadas);
                }
            }

            else
                Console.WriteLine("fail...");
        }

    }
}