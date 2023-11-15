using EAgendaMedica.Dominio.ModuloConsulta;
using EAgendaMedica.Dominio.ModuloMedico;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgendaUnitTests
{
    [TestClass]
    public class MedicoUnitTest 
    {
        [TestMethod]
        public void DeveIncluirUmaConsulta()
        {
            var medico = new Medico("Medico", "12345-SC");

            medico.AdicionarConsulta(new Consulta(DateTime.Now, DateTime.Now.TimeOfDay, 60, medico)) ;

            medico.Consultas.Count.Should().Be(1);
        }
    }
}
