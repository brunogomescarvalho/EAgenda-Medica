using EAgendaMedica.Dominio.Compartilhado;
using EAgendaMedica.Dominio.ModuloConsulta;
using EAgendaMedica.Infra.Compartilhado;


namespace EAgendaMedica.Infra.ModuloConsulta
{
    public class RepositorioConsulta : RepositorioAtividadeBase<Consulta>, IRepositorioConsulta
    {
        public RepositorioConsulta(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
            
        }
    }
}
