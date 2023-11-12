using EAgendaMedica.Dominio.ModuloCirurgia;
using EAgendaMedica.Dominio.ModuloConsulta;
using Taikandi;

namespace EAgendaMedica.Dominio.ModuloMedico
{
    public class Medico
    {
        public Guid Id { get; set; }

        public string CRM { get; set; }

        public string Nome { get; set; }

        public List<Cirurgia> Cirurgias { get; set; }

        public List<Consulta> Consultas { get; set; }

        public Medico()
        {
            Id = SequentialGuid.NewGuid();
        }

    }
}

