using EAgendaMedica.Dominio.ModuloCirurgia;
using EAgendaMedica.Dominio.ModuloConsulta;
using EAgendaMedica.Dominio.ModuloMedico;
using EAgendaMedica.Dominio.Servicos;
using FluentAssertions;

namespace EAgendaUnitTests
{
    [TestClass]
    public class VerificadorDescansoUnitTests
    {
        DateTime hoje = DateTime.Now;

        TimeSpan dezHoras = TimeSpan.Parse("10:00");
        TimeSpan dozeHoras = TimeSpan.Parse("12:00");
        TimeSpan quatorzeHoras = TimeSpan.Parse("14:00");
        TimeSpan dezesseisHoras = TimeSpan.Parse("16:00");
        TimeSpan dezoitoHoras = TimeSpan.Parse("18:00");
        TimeSpan vinteHoras = TimeSpan.Parse("20:00");

        Medico medico = new Medico("Medico1", "12345-SC");


        [TestMethod]
        public void Deve_Validar_Consulta()
        {
            var consulta = new Consulta(hoje, dezHoras, 60, medico);

            bool ehValido = consulta.VerificarDescansoMedico();

            ehValido.Should().BeTrue();
        }


        [TestMethod]
        public void Se_RegistroAnterior_ForConsulta_E_DescansoForMenor_Que20Minutos_Entao_Retorna_False()
        {
            medico.AdicionarConsulta(new Consulta(hoje, dezHoras, 120, medico));

            var consulta = new Consulta(hoje, dozeHoras, 60, medico);

            consulta.VerificarDescansoMedico().Should().BeFalse();
        }

        [TestMethod]
        public void Se_RegistroAnterior_ForConsulta_E_DescansoForMaior_Que20Minutos_Entao_Retorna_True()
        {
            medico.AdicionarConsulta(new Consulta(hoje, dezHoras, 90, medico));

            var consulta = new Consulta(hoje, dozeHoras, 60, medico);

            consulta.VerificarDescansoMedico().Should().BeTrue();
        }


        [TestMethod]
        public void Ao_MarcarCirurgia_DeveHaverIntervalo_240Minutos_RegistroPosterior_RetornaFalse()
        {
            var medicos = new List<Medico>() { medico };

            medico.AdicionarCirurgia(new Cirurgia(hoje, vinteHoras, 180, medicos));

            var cirurgia = new Cirurgia(hoje, quatorzeHoras, 240, medicos);

            cirurgia.VerificarDescansoMedico().Should().BeFalse();
        }


        [TestMethod]
        public void Ao_MarcarCirurgia_DeveHaverIntervalo_240Minutos_RegistroPosterior_RetornaTrue()
        {
            var medicos = new List<Medico>() { medico };

            medico.AdicionarCirurgia(new Cirurgia(hoje, vinteHoras, 180, medicos));

            var cirurgia = new Cirurgia(hoje, dezHoras, 240, medicos);

            cirurgia.VerificarDescansoMedico().Should().BeTrue();
        }

    }
}