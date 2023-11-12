using Taikandi;

namespace EAgendaMedica.Dominio.Compartilhado
{
    public class EntidadeBase<T> where T:EntidadeBase<T>
    {
        public Guid Id { get; set; }

        public EntidadeBase()
        {
            Id = SequentialGuid.NewGuid();
        }
    }
}
