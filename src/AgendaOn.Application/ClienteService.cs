using AgendaOn.Domain.Entities;
using AgendaOn.Domain.Interfaces.Repositories;
using AgendaOn.Domain.Interfaces.Services;

namespace AgendaOn.Application
{
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly IPrestadorRepository _prestadorRepository;

        public ClienteService(IClienteRepository clienteRepository,
                                IPrestadorRepository prestadorRepository)
        {
            this._clienteRepository = clienteRepository;
            this._prestadorRepository = prestadorRepository;
        }

        public Cliente BuscarClientePorId(int id)
        {
            return _clienteRepository.SelecionarPorId(id);
        }

        public int Cadastrar(Usuario usuario)
        {
           
            return _clienteRepository.Incluir(new Cliente()
                                            {
                                                Usuario = usuario
                                            });
        }

        public IEnumerable<Prestador> ListarPrestadores()
        {
            return _prestadorRepository.SelecionarTodos();
        }
    }
}
