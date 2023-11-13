using EAgendaMedica.Dominio;
using EAgendaMedica.Dominio.ModuloMedico;
using EAgendaMedica.Infra.Compartilhado;

namespace EAgendaMedica.Infra.ModuloMedico
{
    public class RepositorioMedico : IRepositorioMedico
    {
        protected DbSet<Medico> registros;

        private readonly EAgendaMedicaDBContext dbContext;

        public RepositorioMedico(IContextoPersistencia contextoPersistencia)
        {
            dbContext = (EAgendaMedicaDBContext)contextoPersistencia;

            registros = dbContext.Set<Medico>();
        }


        public async Task Inserir(Medico registro)
        {
            await registros.AddAsync(registro);
        }

        public async Task<List<Medico>> SelecionarTodos()
        {
            return await registros
                .Include(x => x.Consultas)
                .Include(x => x.Cirurgias)
                .ToListAsync();
        }

        public async Task<Medico> SelecionarPorId(Guid id)
        {
            return await registros.Where(x => x.Id == id)
                .Include(x => x.Id)
                .FirstAsync();
        }

        public async Task<Medico> SelecionarPorCRM(string crm)
        {
            return await registros.Where(x => x.CRM == crm)
                 .Include(x => x.Consultas)
                 .Include(x => x.Cirurgias)
                 .FirstAsync();
        }

        public void Excluir(Medico registro)
        {
            registros.Remove(registro);
        }

        public void Editar(Medico registro)
        {
            registros.Update(registro);
        }

        public async Task<List<Medico>> SelecionarComMaisAtendimentosNoPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            return await registros.Where(x =>
                 x.TodasAtividades().Any(atividade =>
                 atividade.Data >= dataInicial && atividade.Data <= dataFinal))
                .OrderBy(x => x.TotalDeAtendimentos).Take(10)
                .ToListAsync();
        }
    }
}
