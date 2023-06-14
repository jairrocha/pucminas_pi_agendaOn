using AgendaOn.Domain.Entities;
using AgendaOn.Domain.Interfaces.Repositories;
using AgendaOn.Domain.Interfaces.Services;

namespace AgendaOn.Application
{
    public class PrestadorService : IPrestadorService
    {
        private readonly IPrestadorRepository _prestadorRepository;
        private readonly IHorarioService _horarioService;

        public PrestadorService(IPrestadorRepository prestadorRepository, IHorarioService horarioService)
        {
            _prestadorRepository = prestadorRepository;
            _horarioService = horarioService;
        }

        public Prestador BuscarPrestadorPorId(int id)
        {
            return _prestadorRepository.SelecionarPorId(id);
        }

        public int Cadastrar(Usuario usuario, decimal preco)
        {
            var prestador = new Prestador()
            {
                Usuario = usuario,
                Preco = preco
            };

            int id = _prestadorRepository.Incluir(prestador);
            prestador.Id = id;
            _horarioService.DenifinirAgendaPadrao(prestador);
            return id;

        }

  
    }
}
