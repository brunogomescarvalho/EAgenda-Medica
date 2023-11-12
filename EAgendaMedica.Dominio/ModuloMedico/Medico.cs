using EAgendaMedica.Dominio.Compartilhado;
using EAgendaMedica.Dominio.Copartilhado;
using Taikandi;

namespace EAgendaMedica.Dominio.ModuloMedico
{
    public class Medico 
    {
        public Guid Id { get; set; }

        public string CRM { get; set; }
        public string Nome { get; set; }
        public List<Atividade> Atividades { get; set; }

        public Medico()
        {
            Atividades = new List<Atividade>();
            Id = SequentialGuid.NewGuid();
        }

    }
}

