using AgendaOn.Domain.Entities;
using AgendaOn.Domain.Enums;
using AgendaOn.Domain.Interfaces.Repositories;
using AgendaOn.Domain.Interfaces.Services;

namespace AgendaOn.Application
{
    public class UsuarioService : IUsuarioService
    {
        
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPrestadorService _prestadorService;
        private readonly IClienteService _clienteService;
        
        public UsuarioService(IUsuarioRepository usuarioRepository,
            IPrestadorService prestadorService,
            IClienteService clienteService)
        {
            _usuarioRepository = usuarioRepository;
            _prestadorService = prestadorService;
            _clienteService = clienteService;
            
        }

        public Usuario? BuscarUsuario(string id)
        {
            return _usuarioRepository.BuscarUsuario(id);
        }

        public int Cadastrar(TipoUsuario tipoUsuario, string nome, string email, string idEntity, decimal valor = 0)
        {
            var user = _usuarioRepository.Cadastrar(nome, email, idEntity);

            if (TipoUsuario.CLIENTE.Equals(tipoUsuario) && user != null)
            {
                return CadastrarCliente(user);
            }
            else if (TipoUsuario.PRESTADOR.Equals(tipoUsuario) && user != null)
            {
                return CadastrarPrestador(user, valor);
            }

            return 0;

        }

        private int CadastrarCliente(Usuario usuario)
        {
            return _clienteService.Cadastrar(usuario);
        }

        private int CadastrarPrestador(Usuario usuario, decimal preco)
        {
            return _prestadorService.Cadastrar(usuario, preco);
        }

    }
}
