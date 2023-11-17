using EAgendaMedica.Dominio.ModuloCirurgia;
using EAgendaMedica.Infra.Compartilhado;

namespace EAgendaMedica.Infra.ModuloCirurgia
{
    public class RepositorioCirurgia : RepositorioAtividadeBase<Cirurgia>, IRepositorioCirurgia
    {
        public RepositorioCirurgia(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
        }

        public async Task<List<Cirurgia>> ObterCirurgiasPorMedico(string CRM)
        {
            return await registros
                .Where(x => x.Medicos
                .Any(x => x.CRM == CRM))
                .Include(x => x.Medicos)
                .ToListAsync();
        }

        public override async Task<List<Cirurgia>> SelecionarTodos()
        {
            return await registros.Include(x => x.Medicos).ToListAsync();
        }
    }
}


