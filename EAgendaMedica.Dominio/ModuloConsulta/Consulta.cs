using EAgendaMedica.Dominio.Copartilhado;
using EAgendaMedica.Dominio.ModuloMedico;

namespace EAgendaMedica.Dominio.ModuloConsulta
{
    public class Consulta : Atividade<Consulta>
    {
        public Guid MedicoId { get; set; }
        public Medico Medico { get; set; }
    }
}

