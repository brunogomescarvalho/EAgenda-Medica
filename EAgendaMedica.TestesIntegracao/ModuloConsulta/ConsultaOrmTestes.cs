using EAgendaMedica.Dominio.ModuloConsulta;
using EAgendaMedica.Dominio.ModuloMedico;
using EAgendaMedica.TestesIntegracao.Compartilhado;
using FluentAssertions;

namespace EAgendaMedica.TestesIntegracao.ModuloConsulta
{
    [TestClass]
    public class ConsultaOrmTestes : TestsIntegracaoBase
    {

        [TestMethod]
        public async Task Deve_Cadastrar_Nova_Consulta()
        {
            var medico = new Medico("medico", "12345-SC");

            await repositorioMedico.Inserir(medico);

            await dbContext.SaveChangesAsync();

            var medicoParaConsulta = await repositorioMedico.SelecionarPorCRM("12345-SC");

            var consulta = new Consulta()
            {
                DataInicio = DateTime.Now,
                HoraInicio = TimeSpan.Parse("10:00:00"),
                DuracaoEmMinutos = 120,
                Medico = medicoParaConsulta
            };

            await repositorioConsulta.Inserir(consulta);

            await dbContext.SaveChangesAsync();

            repositorioConsulta.SelecionarTodos().Result.Should().HaveCount(1);

        }

    }
}
