﻿using EAgendaMedica.Dominio.ModuloMedico;

namespace EAgendaMedica.Dominio
{
    public interface IRepositorioMedico : IRepositorio<Medico>
    {
        Task<Medico> SelecionarPorCRM(string crm);

        Task<List<Medico>> SelecionarComMaisAtendimentosNoPeriodo(DateTime dataInicial, DateTime dataFinal);
    }
}