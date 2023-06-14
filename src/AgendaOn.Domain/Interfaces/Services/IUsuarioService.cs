using AgendaOn.Domain.Entities;
using AgendaOn.Domain.Enums;

namespace AgendaOn.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Usuario? BuscarUsuario(string id);
        int Cadastrar(TipoUsuario tipoUsuario, string nome, string email, string idEntity, decimal preco = 0);
    }
}
