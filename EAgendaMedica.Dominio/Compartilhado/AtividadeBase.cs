namespace EAgendaMedica.Dominio.Compartilhado
{
    public abstract class Atividade : EntidadeBase<Atividade>
    {
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }

    }
}



