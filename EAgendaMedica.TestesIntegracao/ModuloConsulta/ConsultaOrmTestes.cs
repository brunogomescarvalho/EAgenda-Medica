using EAgendaMedica.Dominio.ModuloConsulta;
using EAgendaMedica.TestesIntegracao.Compartilhado;
using FluentAssertions;

namespace EAgendaMedica.TestesIntegracao.ModuloConsulta
{
    [TestClass]
    public class ConsultaOrmTestes : TestsIntegracaoBase
    {

        public ConsultaOrmTestes() : base()
        {
            this.dbContext.RemoveRange(this.dbContext.Set<Consulta>());
        }


        [TestMethod]
        public async Task Deve_Cadastrar_Nova_Consulta()
        {
            var medico = await repositorioMedico.SelecionarPorCRM("12345-SC");

            var consulta = new Consulta()
            {
                DataInicio = DateTime.Now,
                HoraInicio = TimeSpan.Parse("10:00:00"),
                DuracaoEmMinutos = 120,
                Medico = medico
            };

            await repositorioConsulta.Inserir(consulta);

            await dbContext.SaveChangesAsync();

            repositorioConsulta.SelecionarTodos().Result.Should().HaveCount(1);

        }

    }
}
