using EAgendaMedica.Dominio.Copartilhado;
using EAgendaMedica.Dominio.ModuloMedico;

namespace EAgendaMedica.Dominio.ModuloConsulta
{
    public class Consulta : Atividade
    {
        public Guid MedicoId { get; set; }
        public Medico Medico { get; set; }

        public void AdicionarMedico(Medico medico)
        {
            Medico = medico;
            MedicoId = Medico.Id;
            medico.AdicionarConsulta(this);
        }
    }
}

