using AgendaOn.Domain.Entities;

namespace AgendaOn.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntidade> where TEntidade : EntityBase
    {
          
        int Incluir(TEntidade entidade);
        void Incluir(IEnumerable<TEntidade> entidade);
        void Excluir(int Id);
        void Alterar(TEntidade entidade);
        TEntidade SelecionarPorId(int Id);


    }
}
