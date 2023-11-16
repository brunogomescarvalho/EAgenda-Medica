﻿using EAgendaMedica.Dominio;
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
                .ToListAsync();
        }

        public async Task<Medico> SelecionarPorId(Guid id)
        {
            var medico = await registros.Where(x => x.Id == id)
                .Include(x => x.Cirurgias)
                .Include(x=>x.Consultas)
                .FirstOrDefaultAsync();

            return medico!;
        }

        public async Task<Medico> SelecionarPorCRM(string crm)
        {
            var medico = await registros.Where(x => x.CRM == crm)
                 .Include(x => x.Consultas)
                 .Include(x => x.Cirurgias)
                 .FirstOrDefaultAsync();

            return medico!;
        }

        public void Excluir(Medico registro)
        {
            registros.Remove(registro);
        }

        public void Editar(Medico registro)
        {
            registros.Update(registro);
        }

        public List<Medico> SelecionarComMaisAtendimentosNoPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            var medicosComRegistros = registros.AsEnumerable()
            .OrderByDescending(x => x.TotalDeAtendimentos)
            .Where(m => m.TodasAtividades()
            .Any(atividade => atividade.DataInicio >= dataInicial && atividade.DataInicio <= dataFinal))
            .Take(10)
            .ToList();

            return medicosComRegistros;
        }
    }
}
