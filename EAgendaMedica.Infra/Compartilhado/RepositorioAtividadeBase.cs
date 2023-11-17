using EAgendaMedica.Dominio.Compartilhado;

namespace EAgendaMedica.Infra.Compartilhado
{
    public class RepositorioAtividadeBase<T> : IRepositorioAtividadeBase<T> where T : Atividade
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

        public async Task<List<T>> SelecionarParaHoje()
        {
            return await registros.Where(x => x.DataInicio.Date == DateTime.Now.Date).ToListAsync();
        }

        public async Task<List<T>> SelecionarPorPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            return await registros.Where(x => x.DataInicio.Date >= dataInicial.Date && x.DataInicio.Date <= dataFinal.Date).ToListAsync();
        }

        public async Task<List<T>> SelecionarProximos30Dias()
        {
            return await registros.Where(x => x.DataInicio.Date > DateTime.Today && x.DataInicio.Date < DateTime.Now.Date.AddDays(30)).ToListAsync();
        }

        public async Task<List<T>> SelecionarUltimos30Dias()
        {
            return await registros.Where(x => x.DataInicio.Date < DateTime.Today && x.DataInicio.Date > DateTime.Now.Date.AddDays(-30)).ToListAsync();
        }
    }
}
