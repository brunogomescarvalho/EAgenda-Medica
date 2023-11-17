using EAgendaMedica.Dominio.ModuloCirurgia;
using EAgendaMedica.Dominio.ModuloMedico;
using EAgendaMedica.TestesIntegracao.Compartilhado;
using FizzWare.NBuilder;
using FluentAssertions;

namespace EAgendaMedica.TestesIntegracao.ModuloCirurgia
{
    [TestClass]
    public class RepositorioCirurgiaOrmTests : TestesIntegracaoBase
    {
        [TestMethod]
        public async Task Deve_Selecionar_Cirurgias_Futuras()
        {
            //arrange
            var medico = Builder<Medico>.CreateNew().Build();

            var cirurgiaPassada = new Cirurgia(DateTime.Now.AddDays(-2), TimeSpan.Parse("10:00"), 240, new List<Medico>() { medico });
            var cirurgiaHoje = new Cirurgia(DateTime.Now, TimeSpan.Parse("10:00"), 240, new List<Medico>() { medico });
            var cirurgiaFutura = new Cirurgia(DateTime.Now.AddDays(2), TimeSpan.Parse("10:00"), 240, new List<Medico>() { medico });

            await repositorioCirurgia.Inserir(cirurgiaPassada);
            await repositorioCirurgia.Inserir(cirurgiaHoje);
            await repositorioCirurgia.Inserir(cirurgiaFutura);

            await dbContext.SalvarDados();

            //action
            var cirurgiasFuturas = await repositorioCirurgia.SelecionarProximos30Dias();

            //assert
            cirurgiasFuturas[0].Should().BeSameAs(cirurgiaFutura);

            cirurgiasFuturas.Count.Should().Be(1);
        }


        [TestMethod]
        public async Task Deve_Selecionar_Cirurgias_Passadas()
        {
            //arrange
            var medico = Builder<Medico>.CreateNew().Build();

            var cirurgiaPassada = new Cirurgia(DateTime.Now.AddDays(-2), TimeSpan.Parse("10:00"), 240, new List<Medico>() { medico });
            var cirurgiaHoje = new Cirurgia(DateTime.Now, TimeSpan.Parse("10:00"), 240, new List<Medico>() { medico });
            var cirurgiaFutura = new Cirurgia(DateTime.Now.AddDays(2), TimeSpan.Parse("10:00"), 240, new List<Medico>() { medico });

            await repositorioCirurgia.Inserir(cirurgiaPassada);
            await repositorioCirurgia.Inserir(cirurgiaHoje);
            await repositorioCirurgia.Inserir(cirurgiaFutura);

            await dbContext.SalvarDados();

            //action
            var cirurgiasPassadas = await repositorioCirurgia.SelecionarUltimos30Dias();

            //assert
            cirurgiasPassadas[0].Should().BeSameAs(cirurgiaPassada);

            cirurgiasPassadas.Count.Should().Be(1);
        }


        [TestMethod]
        public async Task Deve_Selecionar_Cirurgias_De_Hoje()
        {
            //arrange
            var medico = Builder<Medico>.CreateNew().Build();

            var cirurgiaPassada = new Cirurgia(DateTime.Now.AddDays(-2), TimeSpan.Parse("10:00"), 240, new List<Medico>() { medico });
            var cirurgiaHoje = new Cirurgia(DateTime.Now, TimeSpan.Parse("10:00"), 240, new List<Medico>() { medico });
            var cirurgiaFutura = new Cirurgia(DateTime.Now.AddDays(2), TimeSpan.Parse("10:00"), 240, new List<Medico>() { medico });

            await repositorioCirurgia.Inserir(cirurgiaPassada);
            await repositorioCirurgia.Inserir(cirurgiaHoje);
            await repositorioCirurgia.Inserir(cirurgiaFutura);

            await dbContext.SalvarDados();

            //action
            var cirurgiasParaHoje = await repositorioCirurgia.SelecionarParaHoje();

            //assert
            cirurgiasParaHoje[0].Should().BeSameAs(cirurgiaHoje);

            cirurgiasParaHoje.Count.Should().Be(1);
        }


        [TestMethod]
        public async Task Deve_Selecionar_Cirurgias_PorPeriodo()
        {
            //arrange
            var medico = Builder<Medico>.CreateNew().Build();

            var semanaPassada = new List<Cirurgia>() {

                 new Cirurgia(DateTime.Now.AddDays(-7), TimeSpan.Parse("10:00"), 240, new List<Medico>() { medico }),
                 new Cirurgia(DateTime.Now.AddDays(-6), TimeSpan.Parse("10:00"), 240, new List<Medico>() { medico }),
                 new Cirurgia(DateTime.Now.AddDays(-5), TimeSpan.Parse("10:00"), 240, new List<Medico>() { medico }),
             };

            var semanaAtual = new List<Cirurgia> {

                new Cirurgia(DateTime.Now.AddDays(-4), TimeSpan.Parse("10:00"), 240, new List<Medico>() { medico }),
                new Cirurgia(DateTime.Now, TimeSpan.Parse("10:00"), 240, new List<Medico>() { medico }),
                new Cirurgia(DateTime.Now.AddDays(2), TimeSpan.Parse("10:00"), 240, new List<Medico>() { medico })
            };

            var semanaQueVem = new List<Cirurgia>() {

                new Cirurgia(DateTime.Now.AddDays(3), TimeSpan.Parse("10:00"), 240, new List<Medico>() { medico }),
                new Cirurgia(DateTime.Now.AddDays(4), TimeSpan.Parse("10:00"), 240, new List<Medico>() { medico }),
                new Cirurgia(DateTime.Now.AddDays(5), TimeSpan.Parse("10:00"), 240, new List<Medico>() { medico })
            };

            foreach (var item in semanaQueVem)
                await repositorioCirurgia.Inserir(item);

            foreach (var item in semanaAtual)
                await repositorioCirurgia.Inserir(item);

            foreach (var item in semanaPassada)
                await repositorioCirurgia.Inserir(item);

            dbContext.SaveChanges();

            //action
            var cirurgiasParaEssaSemana = await repositorioCirurgia.SelecionarPorPeriodo(DateTime.Now.AddDays(-4), DateTime.Now.AddDays(2));

            //assert
            cirurgiasParaEssaSemana.Count.Should().Be(3);

            cirurgiasParaEssaSemana.Should().BeEquivalentTo(semanaAtual);
        }
    }
}
