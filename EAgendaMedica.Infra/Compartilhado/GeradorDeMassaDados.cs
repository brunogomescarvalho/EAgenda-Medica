using EAgendaMedica.Dominio.ModuloCirurgia;
using EAgendaMedica.Infra.Compartilhado;
using EAgendaMedica.Dominio.ModuloConsulta;
using EAgendaMedica.Dominio.ModuloMedico;
using EAgendaMedica.Infra.ModuloCirurgia;
using EAgendaMedica.Infra.ModuloConsulta;
using EAgendaMedica.Infra.ModuloMedico;
using EAgendaMedica.Dominio;

namespace EAgendaMedica.ConsoleApp
{
    public class GeradorDeMassaDados

    {
        readonly EAgendaMedicaDBContext dbContext = null!;

        readonly IRepositorioConsulta resConsulta = null!;
        readonly IRepositorioCirurgia resCirurgia = null!;
        readonly IRepositorioMedico resMed = null!;

        public GeradorDeMassaDados(EAgendaMedicaDBContext dbContext)
        {
            this.dbContext = dbContext;
            resCirurgia = new RepositorioCirurgia(dbContext);
            resConsulta = new RepositorioConsulta(dbContext);
            resMed = new RepositorioMedico(dbContext);
        }

        public async Task GerarMassaDeDados()
        {
            LimparTabelas(dbContext);

            var medicos = GerarMedicos(20);

            foreach (var item in medicos)
            {
                await resMed.Inserir(item);

                await dbContext.SaveChangesAsync();
            }

            var medicosCadastrados = await resMed.SelecionarTodos();

            var consultas = GerarConsultas(10, medicosCadastrados);

            var cirurgias = GerarCirurgias(10, medicosCadastrados);

            foreach (var item in consultas)
            {
                await resConsulta.Inserir(item);
            }

            foreach (var item in cirurgias)
            {
                await resCirurgia.Inserir(item);
            }

            await dbContext.SaveChangesAsync();
        }



        private static List<Medico> GerarMedicos(int v)
        {
            var medicos = new List<Medico>();

            for (int i = 0; i < v; i++)
            {
                medicos.Add(new Medico($"Medico {i + 9}", $"123{i}-SC"));
            }

            return medicos;
        }

        private static List<Consulta> GerarConsultas(int v, List<Medico> medicos)
        {
            var consultas = new List<Consulta>();

            var hora = 0;

            var data = DateTime.Now;

            for (int i = 0; i < v; i++)
            {
                if (hora >= 24)
                {
                    hora = 1;
                    data = data.AddDays(3);
                }

                if (i % 2 == 0)
                    data = data.AddDays(1);

                var horaInicial = TimeSpan.Parse($"{hora += 1}:00");

                var index = new Random().Next(0, medicos.Count - 1);

                Medico medico = medicos[index];

                var consulta = new Consulta(data, horaInicial, 120, medico);

                var ehValida = consulta.VerificarDescansoMedico();

                if (ehValida == true)
                    consultas.Add(consulta);

                hora += 2;
            }

            return consultas;

        }

        private static List<Cirurgia> GerarCirurgias(int v, List<Medico> medicos)
        {
            var cirurgias = new List<Cirurgia>();

            var hora = 2;

            var data = DateTime.Now;

            for (int i = 0; i < v; i++)
            {
                if (hora >= 24)
                {
                    hora = 1;
                    data = data.AddDays(2);
                }

                if (i % 2 == 0)
                    data = data.AddDays(1);

                var horaInicial = TimeSpan.Parse($"{hora}:00");

                var medicosParticipantes = medicos.Take(i + 1).ToList();

                var cirurgia = new Cirurgia(data, horaInicial, 120, medicosParticipantes);

                var ehValida = cirurgia.VerificarDescansoMedico();

                if (ehValida == true)
                    cirurgias.Add(cirurgia);

                hora += 6;
            }

            return cirurgias;

        }
        private static void LimparTabelas(EAgendaMedicaDBContext dbContext)
        {
            dbContext.Set<Consulta>().RemoveRange(dbContext.Set<Consulta>());
            dbContext.Set<Cirurgia>().RemoveRange(dbContext.Set<Cirurgia>());
            dbContext.Set<Medico>().RemoveRange(dbContext.Set<Medico>());
            dbContext.SaveChanges();
        }
    }

}
