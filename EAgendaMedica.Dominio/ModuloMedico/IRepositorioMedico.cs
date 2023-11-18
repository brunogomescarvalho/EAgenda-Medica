using EAgendaMedica.Dominio.ModuloMedico;

namespace EAgendaMedica.Dominio
{
    public interface IRepositorioMedico : IRepositorio<Medico>
    {
        Task<Medico> SelecionarPorCRM(string crm);

        Task<List<Medico>>SelecionarMedicosComAtendimentosNoPeriodo(DateTime dataInicial, DateTime dataFinal);

        Task<List<Medico>> SelecionarMuitos(List<Guid> medicosId);
    }
}