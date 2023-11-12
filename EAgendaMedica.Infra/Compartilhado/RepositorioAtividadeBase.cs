using EAgendaMedica.Dominio.Compartilhado;

namespace EAgendaMedica.Infra.Compartilhado
{
    public class RepositorioAtividadeBase<T> : IRepositorio<T> where T : Atividade
    {
        protected DbSet<T> registros;

        private readonly EAgendaMedicaDBContext dbContext;

        public RepositorioAtividadeBase(IContextoPersistencia contextoPersistencia)
        {
            dbContext = (EAgendaMedicaDBContext)contextoPersistencia;

            registros = dbContext.Set<T>();
        }

        public virtual async Task Inserir(T registro)
        {
            await registros.AddAsync(registro);
        }

        public virtual async Task<List<T>> SelecionarTodos()
        {
            return await registros.ToListAsync();
        }

        public virtual async Task<T> SelecionarPorId(Guid id)
        {
            return await registros.Where(x => x.Id == id).FirstAsync();
        }

        public virtual void Excluir(T registro)
        {
            registros.Remove(registro);
        }

        public virtual void Editar(T registro)
        {
            registros.Update(registro);
        }
    }
}
