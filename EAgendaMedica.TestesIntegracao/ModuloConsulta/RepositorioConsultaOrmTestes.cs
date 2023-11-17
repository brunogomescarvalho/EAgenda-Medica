using EAgendaMedica.Dominio.ModuloConsulta;
using EAgendaMedica.Dominio.ModuloMedico;
using EAgendaMedica.TestesIntegracao.Compartilhado;
using FizzWare.NBuilder;
using FluentAssertions;

namespace EAgendaMedica.TestesIntegracao.ModuloConsulta
{
    [TestClass]
    public class RepositorioConsultaOrmTestes : TestesIntegracaoBase
    {

        [TestMethod]
        public async Task Deve_Cadastrar_Nova_Consulta()
        {
            //arrange
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

            //action
            await repositorioConsulta.Inserir(consulta);

            await dbContext.SaveChangesAsync();

            //assert
            repositorioConsulta.SelecionarTodos().Result.Should().HaveCount(1);

        }

        [TestMethod]
        public async Task Deve_Editar_Consulta()
        {
            //arrange
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


            //action
            var lista = await repositorioConsulta.SelecionarTodos();

            var consultaParaEditar = lista[0];

            consultaParaEditar.DuracaoEmMinutos = 60;

            repositorioConsulta.Editar(consultaParaEditar);

            dbContext.SaveChanges();

            //assert
            var listaNova = await repositorioConsulta.SelecionarTodos();

            var consultaEditada = listaNova[0];

            consultaEditada.DuracaoEmMinutos.Should().Be(60);

            consultaEditada.HoraTermino.Should().Be(TimeSpan.Parse("11:00"));
        }

        [TestMethod]
        public async Task Deve_Excluir_Consulta()
        {
            //arrange
            var consulta = Builder<Consulta>.CreateNew().Build();

            consulta.Medico = new Medico("medico", "12345-SC");

            await repositorioConsulta.Inserir(consulta);

            await dbContext.SalvarDados();

            //action
            repositorioConsulta.Excluir(consulta);

            await dbContext.SaveChangesAsync();

            //assert
            var consultas = await repositorioConsulta.SelecionarTodos();

            consultas.Count.Should().Be(0);
        }

    }
}
