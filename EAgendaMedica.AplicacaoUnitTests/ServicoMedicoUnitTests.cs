using EAgendaMedica.Dominio;
using EAgendaMedica.Dominio.Copartilhado;
using EAgendaMedica.Dominio.ModuloMedico;
using EAgendaMedica.Aplicacao.ModuloMedico;
using Moq;
using FluentResults.Extensions.FluentAssertions;
using FluentAssertions;
using FluentValidation.Results;

namespace EAgendaMedica.AplicacaoUnitTests
{
    [TestClass]
    public class ServicoMedicoUnitTests
    {
        Mock<IRepositorioMedico> repositorioMoq;

        ServicoMedico servicoMedico;

        Mock<ValidadorMedico> validadorMock;

        Mock<IContextoPersistencia> contexto;

        public ServicoMedicoUnitTests()
        {
            repositorioMoq = new Mock<IRepositorioMedico>();

            contexto = new Mock<IContextoPersistencia>();

            validadorMock = new Mock<ValidadorMedico>();

            servicoMedico = new ServicoMedico(repositorioMoq.Object, contexto.Object);
        }


        [TestMethod]
        public void Deve_Cadastrar_Medico_Se_Ele_for_Valido()
        {
            var medico = new Medico("medico", "12345-SC");

            var result = servicoMedico.Inserir(medico);

            result.Result.Should().BeSuccess();
        }

        [TestMethod]
        public void Nao_Deve_Cadastrar_Medico_Se_CRM_for_invalido()
        {
            var medico = new Medico("medico", "12-SC");

            var result = servicoMedico.Inserir(medico);

            result.Result.Should().BeFailure();
        }

        [TestMethod]
        public void Nao_Deve_Cadastrar_Medico_Se_Nome_for_invalido()
        {
            var medico = new Medico("m", "12345-SC");

            var result = servicoMedico.Inserir(medico);

            result.Result.Should().BeFailure();
        }

        [TestMethod]
        public void Deve_Editar_Se_Ele_for_Valido()
        {
            var medico = new Medico("medico", "12345-SC");

            var result = servicoMedico.Editar(medico);

            result.Result.Should().BeSuccess();

            repositorioMoq.Verify(x=>x.Editar(medico), Times.Once);
        }

        [TestMethod]
        public void Nao_Deve_Editar_Se_CRM_for_Invalido()
        {
            var medico = new Medico("medico", "5-SC");

            var result = servicoMedico.Editar(medico);

            result.Result.Should().BeFailure();

            repositorioMoq.Verify(x => x.Editar(medico), Times.Never);
        }

        [TestMethod]
        public void Nao_Deve_Editar_Se_Nome_for_Invalido()
        {
            var medico = new Medico("m", "12345-SC");

            var result = servicoMedico.Editar(medico);

            result.Result.Should().BeFailure();

            repositorioMoq.Verify(x => x.Editar(medico), Times.Never);
        }
    }
}