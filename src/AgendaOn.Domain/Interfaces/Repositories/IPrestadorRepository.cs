using AgendaOn.Domain.Entities;

namespace AgendaOn.Domain.Interfaces.Repositories
{
    public interface IPrestadorRepository: IBaseRepository<Prestador>
    {
        Prestador? SelecionarPorId(int id);
        IEnumerable<Prestador> SelecionarTodos();
        IEnumerable<Prestador> SelecionarPorNome(string nome);
        
    }
}
