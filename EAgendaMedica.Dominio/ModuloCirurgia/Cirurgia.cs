using EAgendaMedica.Dominio.Copartilhado;
using EAgendaMedica.Dominio.ModuloMedico;

namespace EAgendaMedica.Dominio.ModuloCirurgia
{
    public class Cirurgia : Atividade<Cirurgia>
    {
        public List<Medico> Medicos { get; set; }
    }
}

