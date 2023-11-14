using System.ComponentModel.DataAnnotations.Schema;
using Taikandi;

namespace EAgendaMedica.Dominio.Compartilhado
{
    [NotMapped]
    public abstract class Atividade
    {
        public Guid Id { get; set; }

        public DateTime DataInicio
        {
            get => data;
            set
            {
                data = value.Date;
            }
        }

        public TimeSpan HoraInicio
        {
            get => horaInicio;
            set
            {
                data = data.Add(value);
                horaInicio = value;
            }
        }

        public double DuracaoEmMinutos
        {
            get => (DataInicio - DataTermino).TotalMinutes;
            set
            {
                duracaoEmMinutos = value;
                dataHoraTermino = data.AddMinutes(duracaoEmMinutos);
            }
        }

        public TimeSpan HoraTermino { get => DataTermino.TimeOfDay; }
        public DateTime DataTermino { get => dataHoraTermino; }

        private TimeSpan horaInicio;

        private DateTime data;

        private DateTime dataHoraTermino;

        private double duracaoEmMinutos;

        public Atividade(DateTime data, TimeSpan horaInicio, double duracao) : this()
        {
            this.DataInicio = data;
            this.HoraInicio = horaInicio;
            this.DuracaoEmMinutos = duracao;
        }

        public Atividade()
        {
            Id = SequentialGuid.NewGuid();
        }

    }
}



