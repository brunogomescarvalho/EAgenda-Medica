namespace EAgendaMedica.Dominio.Compartilhado
{
    public interface IRepositorioAtividadeBase<T> where T : Atividade
    {
        Task<List<T>> SelecionarProximos30Dias();

        Task<List<T>> SelecionarUltimos30Dias();

        Task<List<T>> SelecionarParaHoje();

        Task<List<T>> SelecionarPorPeriodo(DateTime dataInicial, DateTime dataFinal);

    }
}
