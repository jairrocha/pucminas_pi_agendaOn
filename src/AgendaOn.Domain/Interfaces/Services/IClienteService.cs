using AgendaOn.Domain.Entities;

namespace AgendaOn.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Cliente BuscarClientePorId(int id);

        IEnumerable<Prestador> ListarPrestadores();
        int Cadastrar(Usuario usuario);


    }
}
