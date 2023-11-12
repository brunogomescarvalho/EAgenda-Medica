namespace EAgendaMedica.Dominio.Compartilhado
{
    public interface IRepositorio<T> where T : EntidadeBase<T>
    {
        Task Inserir(T registro);

        Task<List<T>> SelecionarTodos();

        Task<T> SelecionarPorId(Guid id);

        void Excluir(T registro);

        void Editar(T registro);
    }
}
