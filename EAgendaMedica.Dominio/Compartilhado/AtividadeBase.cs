using Taikandi;

namespace EAgendaMedica.Dominio.Copartilhado
{

    public abstract class Atividade<T> where T : Atividade<T>
    {
        public Guid Id { get; set; } 
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }

        public Atividade()
        {
            Id = SequentialGuid.NewGuid();
        }

    }
}



