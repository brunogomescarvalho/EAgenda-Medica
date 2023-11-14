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
        [TestMethod]
        public void Deve_Retornar_ListaVazia_SemComflitos()
        {
            var medico = new Medico { Id = Guid.NewGuid(), CRM = "12345-SC", Nome = "M�dico 1" };

            Arrange(medico);

            var consulta = new Consulta();
            {
                consulta.Data = new DateTime(2023, 11, 12, 10, 26, 0);
                consulta.HoraInicio = consulta.Data.TimeOfDay;
                consulta.HoraTermino = consulta.Data.AddMinutes(20).TimeOfDay;
            }

            var verificador = new VerificadorDescanso(consulta);

            verificador.VerificarMedico(medico).Should().BeEmpty();
        }

  

        private static void Arrange(Medico medico)
        {
            var consultas = new List<Consulta>
                {
                new Consulta { Data = new DateTime(2023, 11, 12, 10, 0, 0)},
                new Consulta { Data = new DateTime(2023, 11, 12, 11, 15, 0)},              
                };

            var cirurgias = new List<Cirurgia>
                {
                new Cirurgia { Data = new DateTime(2023, 11, 12, 9, 30, 0)},
                new Cirurgia { Data = new DateTime(2023, 11, 12, 12, 0, 0)},              
                };

            foreach (var item in cirurgias)
            {
                item.HoraInicio = item.Data.TimeOfDay;
                item.HoraTermino = item.Data.AddMinutes(60).TimeOfDay;
                item.Medicos.Add(medico);
            }

            foreach (var item in consultas)
            {
                item.HoraInicio = item.Data.TimeOfDay;
                item.HoraTermino = item.Data.AddMinutes(20).TimeOfDay;
                item.Medico = medico;
            }

            medico.Cirurgias.AddRange(cirurgias);
            medico.Consultas.AddRange(consultas);
        }
    }
}