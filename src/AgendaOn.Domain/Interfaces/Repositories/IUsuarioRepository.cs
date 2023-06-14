using AgendaOn.Domain.Entities;
using AgendaOn.Domain.Enums;

namespace AgendaOn.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository: IBaseRepository<Usuario>
    {
        Usuario? BuscarUsuario(string id);
        Usuario? Cadastrar(string nome, string email, string IdIdentity);
    }
}
