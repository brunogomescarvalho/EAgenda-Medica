using EAgendaMedica.Dominio.ModuloMedico;
using EAgendaMedica.Dominio.Servicos;

namespace EAgendaMedica.Dominio.ModuloConsulta
{
    public class Consulta : Atividade
    {
        public Guid MedicoId { get; set; }
        public Medico Medico { get; set; }

        public Consulta(DateTime data, TimeSpan horaInicio, int duracao) : base(data, horaInicio, duracao)
        {
        }
        public Consulta()
        {
            Medico = new Medico();
        }
        public void AdicionarMedico(Medico medico)
        {
            Medico = medico;
            MedicoId = Medico.Id;
            medico.AdicionarConsulta(this);
        }

        public List<Atividade> VerificarDescansoMedico()
        {
            return new VerificadorDescanso(this).VerificarMedico(Medico);
        }
    }
}

