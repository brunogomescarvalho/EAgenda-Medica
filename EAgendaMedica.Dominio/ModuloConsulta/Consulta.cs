using EAgendaMedica.Dominio.ModuloMedico;
using EAgendaMedica.Dominio.Servicos;

namespace EAgendaMedica.Dominio.ModuloConsulta
{
    public class Consulta : Atividade
    {
        public Guid MedicoId { get; set; }

        private Medico medico;
        public Medico Medico
        {
            get => medico;
            set
            {
                AdicionarMedico(value);
            }
        }
        public Consulta() { }

        public Consulta(DateTime data, TimeSpan horaInicio, int duracao, Medico medico) : base(data, horaInicio, duracao)
        {
            Medico = medico;
        }
        
        public void AdicionarMedico(Medico medico)
        {
            MedicoId = medico.Id;
            this.medico = medico;
            medico.AdicionarConsulta(this);
        }

        public List<Atividade> VerificarDescansoMedico()
        {
            return new VerificadorDescanso(this).VerificarMedico(Medico);
        }

        public override bool Equals(object? obj)
        {
            return obj is Consulta consulta &&
                   Id.Equals(consulta.Id) &&
                   DataInicio == consulta.DataInicio &&
                   HoraInicio.Equals(consulta.HoraInicio) &&
                   DuracaoEmMinutos == consulta.DuracaoEmMinutos &&
                   HoraTermino.Equals(consulta.HoraTermino) &&
                   DataTermino == consulta.DataTermino &&
                   EqualityComparer<Medico>.Default.Equals(Medico, consulta.Medico);
        }
    }
}

