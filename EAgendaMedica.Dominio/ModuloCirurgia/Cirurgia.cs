using EAgendaMedica.Dominio.ModuloMedico;

namespace EAgendaMedica.Dominio.ModuloCirurgia
{
    public class Cirurgia : Atividade
    {
        private List<Medico> medicos;
        public List<Medico> Medicos
        {
            get => medicos;
            set
            {
                AdicionarEquipeMedica(value);
            }
        }

        public Cirurgia() { }
     
        public Cirurgia(DateTime data, TimeSpan horaInicio, int duracao, List<Medico> medicos) : base(data, horaInicio, duracao)
        {
            Medicos = medicos;
        }

        public void AdicionarEquipeMedica(List<Medico> medicos)
        {
            this.medicos = new List<Medico>();

            foreach (var medico in medicos)
            {
                if (medico != null && this.medicos.Contains(medico) == false)
                {
                    this.medicos.Add(medico);

                    medico.AdicionarCirurgia(this);
                }
            }

        }

        public override bool Equals(object? obj)
        {
            return obj is Cirurgia cirurgia &&
                   Id.Equals(cirurgia.Id) &&
                   DataInicio == cirurgia.DataInicio &&
                   HoraInicio.Equals(cirurgia.HoraInicio) &&
                   DuracaoEmMinutos == cirurgia.DuracaoEmMinutos &&
                   HoraTermino.Equals(cirurgia.HoraTermino) &&
                   DataTermino == cirurgia.DataTermino &&
                   EqualityComparer<List<Medico>>.Default.Equals(Medicos, cirurgia.Medicos);
        }
    }
}

