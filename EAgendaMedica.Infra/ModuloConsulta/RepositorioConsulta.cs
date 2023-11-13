using EAgendaMedica.Dominio.ModuloConsulta;
using EAgendaMedica.Infra.Compartilhado;

namespace EAgendaMedica.Infra.ModuloConsulta
{
    public class RepositorioConsulta : RepositorioAtividadeBase<Consulta>, IRepositorioConsulta
    {
        public RepositorioConsulta(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
            
        }

        public override async Task<List<Consulta>> SelecionarTodos()
        {
            return await registros.Include(x=>x.Medico).ToListAsync();
        }


    }
}
