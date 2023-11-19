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

        public async Task<List<Medico>> SelecionarPorStatus(bool ativo)
        {
            return await registros.Where(x => x.Ativo == ativo)
               .ToListAsync();
        }

        public async Task<Medico> SelecionarPorId(Guid id)
        {
            var medico = await registros.Where(x => x.Id == id)
                .Include(x => x.Cirurgias)
                .Include(x => x.Consultas)
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

        public async Task<List<Medico>> SelecionarMedicosComAtendimentosNoPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            var medicos = await registros
           .Include(x => x.Cirurgias)
           .Include(x => x.Consultas).ToListAsync();

            var medicosComAtendimentos = medicos.Where(medico => medico.TodasAtividades()
            .Any(atividade => atividade.DataInicio >= dataInicial && atividade.DataTermino <= dataFinal)).ToList();

            return medicosComAtendimentos;
        }

        public Task<List<Medico>> SelecionarMuitos(List<Guid> medicosId)
        {
            return registros.Where(x => medicosId.Contains(x.Id)).ToListAsync();
        }
    }
}
