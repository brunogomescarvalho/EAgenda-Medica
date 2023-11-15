using EAgendaMedica.Dominio.ModuloCirurgia;
using EAgendaMedica.Infra.Compartilhado;
using EAgendaMedica.Infra.ModuloCirurgia;
using Microsoft.EntityFrameworkCore;
using EAgendaMedica.Infra.ModuloConsulta;
using EAgendaMedica.Infra.ModuloMedico;
using EAgendaMedica.Dominio.ModuloConsulta;
using EAgendaMedica.Dominio.ModuloMedico;
using EAgendaMedica.Dominio.Compartilhado;

namespace EAgendaMedica.ConsoleApp
{
    public class Program
    {
        private static EAgendaMedicaDBContext dbContext = null!;
        private static RepositorioConsulta resConsulta = null!;
        private static RepositorioCirurgia resCirurgia = null!;
        private static RepositorioMedico resMed = null!;

        static async Task Main(string[] args)
        {
            //dbContext = IniciarContexto();

            //resConsulta = new RepositorioConsulta(dbContext);
            //resCirurgia = new RepositorioCirurgia(dbContext);
            //resMed = new RepositorioMedico(dbContext);

            ////GerarAlgunsDados(dbContext);

            //Console.Clear();

            //await ListarCirurgias();

            //BuscarUmMedicoPorCrm();

            //await ListarOsMedicos();

            //await ListarConsultas();


          //  var at = new Cirurgia(DateTime.Now, TimeSpan.Parse("10:00"), 60);

          


           

           


            


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


        private static async void GerarAlgunsDados(EAgendaMedicaDBContext dbContext)
        {
            await AddCirurgia();
            await AddConsulta();
        }

        private static async Task AddConsulta()
        {
            var consulta = new Consulta()
            {
                Id = Guid.NewGuid(),
                DataInicio = DateTime.Now,
                HoraInicio = TimeSpan.Parse("10:00"),
               // HoraTermino = TimeSpan.Parse("12:00"),
            };
            var med = resMed.SelecionarPorCRM("12345-SC").Result;
            consulta.AdicionarMedico(med);

            await resConsulta.Inserir(consulta);

            dbContext.SaveChanges();
        }

        private static async Task AddCirurgia()
        {
            var cirurgia = new Cirurgia()
            {
                Id = Guid.NewGuid(),
                DataInicio = DateTime.Now,
                HoraInicio = TimeSpan.Parse("10:00"),
               // HoraTermino = TimeSpan.Parse("12:00"),
            };

            var med = resMed.SelecionarPorCRM("12345-SC").Result;
          //  cirurgia.AdicionarMedico(med);

            await resCirurgia.Inserir(cirurgia);

            dbContext.SaveChanges();
        }

        private static void BuscarUmMedicoPorCrm()
        {
            Console.WriteLine("\n---Buscar Médico Por Crm---");

            var med = resMed.SelecionarPorCRM("12345-SC").Result;
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
                    Console.WriteLine(item.Id + " " + item.Medicos[0]);
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
                    Console.WriteLine(item.Id + " " + item.Medico);
                }
            }

            else
                Console.WriteLine("fail...");
        }
    }

    public class Atividade2
    {
        public Guid Id { get; set; }


        public DateTime Data
        {
            get => data;
            set
            {
                data = value.Date;
            }
        }

        public TimeSpan HoraInicio
        {
            get => horaInicio;
            set
            {
                data = data.Add(value);
                horaInicio = value;
            }
        }

        public double DuracaoEmMinutos
        {
            get => (DataHoraTermino - Data).TotalMinutes;
            set
            {
                duracaoEmMinutos = value;
                dataHoraTermino = data.AddMinutes(duracaoEmMinutos);
            }
        }

        public TimeSpan HoraTermino { get => DataHoraTermino.TimeOfDay; }
        public DateTime DataHoraTermino { get => dataHoraTermino; }

        private TimeSpan horaInicio;

        private DateTime data;

        private DateTime dataHoraTermino;

        private double duracaoEmMinutos;

        public Atividade2(DateTime data, TimeSpan horaInicio, double duracao)
        {
            this.Data = data;
            this.HoraInicio = horaInicio;
            this.DuracaoEmMinutos = duracao;
        }
    }
}