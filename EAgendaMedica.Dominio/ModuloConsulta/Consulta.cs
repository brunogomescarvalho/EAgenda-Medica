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
            if (medico != null)
            {
                MedicoId = medico.Id;
                this.medico = medico;
                medico.AdicionarConsulta(this);
            }

        }

        public Consulta(Guid id, DateTime data, TimeSpan horaInicio, int duracao, Medico medico)
        {
            Id = id;
            DataInicio = data;
            HoraInicio = horaInicio;
            DuracaoEmMinutos = duracao;
            Medico = medico;
        }

        public bool VerificarDescansoMedico()
        {
            return new VerificadorDescanso(this).Verificar(Medico);
        }

        public override string ToString()
        {
            var passouDaMeiaNoite = $"Data: {DataInicio:d} - {HoraInicio} -- Término: {DataTermino:d} - {HoraTermino} -- Dr: {Medico}";

            return DataInicio.Date != DataTermino.Date ? passouDaMeiaNoite : $"Data: {DataInicio:d} - Início {HoraInicio} -- Término: {HoraTermino} -- Dr: {Medico}";
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

