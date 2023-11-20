using EAgendaMedica.Dominio.ModuloCirurgia;
using EAgendaMedica.Infra.Compartilhado;
using EAgendaMedica.Dominio.ModuloConsulta;
using EAgendaMedica.Dominio.ModuloMedico;
using EAgendaMedica.Dominio;
using Serilog;

namespace EAgendaMedica.ConsoleApp
{
    public class GeradorDeMassaDados

    {
        readonly EAgendaMedicaDBContext dbContext;
        readonly IRepositorioConsulta resConsulta;
        readonly IRepositorioCirurgia resCirurgia;
        readonly IRepositorioMedico resMed;

        public GeradorDeMassaDados(EAgendaMedicaDBContext dbContext, IRepositorioConsulta resConsulta, IRepositorioCirurgia resCirurgia, IRepositorioMedico resMed)
        {
            this.dbContext = dbContext;
            this.resConsulta = resConsulta;
            this.resCirurgia = resCirurgia;
            this.resMed = resMed;
        }

        public async Task GerarMassaDeDados()
        {
            try
            {
                LimparTabelas(dbContext);

                var medicos = GerarMedicos(30);

                foreach (var item in medicos)
                {
                    await resMed.Inserir(item);

                    await dbContext.SaveChangesAsync();
                }

                var medicoscrmCadastrado = await resMed.SelecionarTodos();

                var consultas = GerarConsultas(20, medicoscrmCadastrado);

                var cirurgias = GerarCirurgias(20, medicoscrmCadastrado);

                foreach (var item in consultas)
                {
                    await resConsulta.Inserir(item);
                }

                foreach (var item in cirurgias)
                {
                    await resCirurgia.Inserir(item);
                }

                await dbContext.SaveChangesAsync();


                var qtdCol = dbContext.Set<Consulta>().Count();
                var qtdCir = dbContext.Set<Cirurgia>().Count();
                var qtdMedico = dbContext.Set<Medico>().Count();

                Log.Logger.Information($"Gerado massa de dados com {qtdCir + qtdCol + qtdMedico} registros");
            }
            catch (Exception ex)
            {
                Log.Error("Não foi possivel gerar dados. Exception: " + ex.Message);
            }
        }



        private static List<Medico> GerarMedicos(int v)
        {
            var medicos = new List<Medico>();

            List<string> crmCadastrado = new();

            for (int i = 0; i < v; i++)
            {
                string crm;

                while (true)
                {
                    crm = "";

                    while (crm.Length != 5)
                        crm += new Random().Next(0, 5).ToString();

                    if (crmCadastrado.Contains(crm))
                        continue;

                    crmCadastrado.Add(crm);

                    medicos.Add(new Medico($"Medico-{i}", $"{crm}-SC"));

                    break;

                }
            }

            return medicos;
        }

        private static List<Consulta> GerarConsultas(int v, List<Medico> medicos)
        {
            var consultas = new List<Consulta>();

            var hora = 0;

            var data = DateTime.Now.AddDays(-5);

            for (int i = 0; i < v; i++)
            {
                if (i % 2 != 0)
                    data = data.AddDays(1);

                if (hora >= 24)
                {
                    hora = 1;
                }

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

            var data = DateTime.Now.AddDays(-5);

            for (int i = 0; i < v; i++)
            {
                if (i % 2 != 0)
                    data = data.AddDays(1);

                if (hora >= 24)
                {
                    hora = 1;
                }

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
