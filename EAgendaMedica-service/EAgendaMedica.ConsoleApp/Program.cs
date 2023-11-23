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

            await GerarMassaDeDados();

            //await MostrarDados();
        }

        private static async Task GerarMassaDeDados()
        {
            var gerador = new GeradorDeMassaDados(dbContext, resConsulta, resCirurgia, resMed);

            await gerador.GerarMassaDeDados();
        }

        private static async Task MostrarDados()
        {
            Console.Clear();

            //await ListarCirurgias();

            //BuscarUmMedicoPorCrm();

            //await ListarOsMedicos();

            //await ListarConsultas();

            //await ListarMedicosOrdemAtendimento();

            await ListarCirurgiasParaHoje();
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
                Console.WriteLine(med + " " + "nr atividades:" + med.TodasAtividades().Count + " Total Horas Trabalhadas" + med.HorasTotaisTrabalhadas);

        }

        private static async Task ListarOsMedicos()
        {
            Console.WriteLine("\n---Listagem de Medicos ---");
            var medicos = await resMed.SelecionarTodos();

            if (medicos.Any())
            {
                foreach (var item in medicos)
                {
                    Console.WriteLine(item + " " + "nr atividades:" + item.TodasAtividades().Count + " Total Horas Trabalhadas" + item.HorasTotaisTrabalhadas);
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
                    item.AtualizarInformacoes(item);

                    Console.WriteLine(item);
                }
            }

            else
                Console.WriteLine("fail...");
        }

        private static async Task ListarCirurgiasParaHoje()
        {
            Console.WriteLine("\n---Listagem Cirurgias De Hoje---");
            var lista = await resConsulta.SelecionarParaHoje();

            if (lista.Any())
            {
                foreach (var item in lista)
                {
                    item.AtualizarInformacoes(item);

                    Console.WriteLine(item);
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
                    item.AtualizarInformacoes(item);

                    Console.WriteLine(item);
                }
            }

            else
                Console.WriteLine("fail...");
        }

        public async static Task ListarMedicosOrdemAtendimento()
        {

            var dataInicio = DateTime.Now.AddDays(-5);

            var dataFim = DateTime.Now.AddDays(5);

            Console.WriteLine($"\n---Listagem Médicos Ordem Atendimento---Período {dataInicio:d} -  {dataFim:d}");

            var lista = await resMed.SelecionarMedicosComAtendimentosNoPeriodo(dataInicio, dataFim);

            if (lista.Any())
            {
                foreach (var item in lista)
                {
                    Console.WriteLine(item + " " + "Atendimentos:" + item.TodasAtividades().Count);
                }
            }

            else
                Console.WriteLine("fail...");
        }

    }
}