using EAgendaMedica.Dominio.ModuloCirurgia;
using EAgendaMedica.Infra.Compartilhado;

namespace EAgendaMedica.Infra.ModuloCirurgia
{
    public class RepositorioCirurgia : RepositorioAtividadeBase<Cirurgia>, IRepositorioCirurgia
    {
        public RepositorioCirurgia(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
        }
    }
}
