using System.ComponentModel.DataAnnotations.Schema;
using Taikandi;

namespace EAgendaMedica.Dominio.Compartilhado
{
    [NotMapped]
    public abstract class Atividade
    {
        public Guid Id { get; set; }


        private DateTime data;

        public DateTime Data
        {
            get => data;
            set
            {
                this.dataHoraTermino = data.AddMinutes(DuracaoEmMinutos);
            }
        }

        public TimeSpan HoraInicio
        {
            get => this.horaInicio;
            set => data = new DateTime(data.Date.Ticks + horaInicio.Ticks);
        }
        public TimeSpan HoraTermino { get; set; }
        public DateTime DataHoraTermino
        {
            get => this.dataHoraTermino = data.AddMinutes(DuracaoEmMinutos);
        }

        private DateTime dataHoraTermino;
        private TimeSpan horaInicio;

        public double DuracaoEmMinutos { get; set; }

        public Atividade()
        {
            Id = SequentialGuid.NewGuid();
        }




    }
}



