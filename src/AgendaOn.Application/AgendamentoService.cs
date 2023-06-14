using AgendaOn.Domain.Entities;
using AgendaOn.Domain.Enums;
using AgendaOn.Domain.Interfaces.Repositories;
using AgendaOn.Domain.Interfaces.Services;

namespace AgendaOn.Application
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository agendamentoRepository;
        private readonly IPrestadorService prestadorService;


        public AgendamentoService(IAgendamentoRepository agendamentoRepository, 
                IPrestadorService prestadorService)
        {
            this.agendamentoRepository = agendamentoRepository;
            this.prestadorService = prestadorService;
        }

        public void Agendar(int clienteId, int prestadorId, int agendaId, DateTime date)
        {
            agendamentoRepository.Agendar(clienteId, prestadorId, agendaId, date);

        }

        public void Alterar(int agendamentoId, int horarioId, DateTime date)
        {
            var agendamento = agendamentoRepository.SelecionarPorId(agendamentoId);
            agendamento.HorarioId = horarioId;
            agendamento.DataAgendamento = date;
            agendamentoRepository.Alterar(agendamento);
            

        }

        public IEnumerable<Agendamento> BuscarAgendamentoClientePorData(int ClienteId, DateTime data)
        {
            return agendamentoRepository.BuscarAgendamentoPorData(ClienteId, data, TipoUsuario.CLIENTE);
        }

        public IEnumerable<Agendamento> BuscarAgendamentoPrestadorPorData(int prestadorId, DateTime data)
        {
            return agendamentoRepository.BuscarAgendamentoPorData(prestadorId, data, TipoUsuario.PRESTADOR);
        }

        public IEnumerable<Horario> BuscarHorariosDisponiveisPrestador(int prestadorId, DateTime data)
        {
            var horariosPrestador = prestadorService.BuscarPrestadorPorId(prestadorId).Horarios;

            var horariosAgendados = agendamentoRepository
                    .BuscarAgendamentoPorData(prestadorId, data, TipoUsuario.PRESTADOR)
                    .Select(_ => _.Horario).ToList();

            //Alternativa ao In
            return horariosPrestador.Where(_ => !horariosAgendados.Any(a => a == _)).ToList();

        }

        public IEnumerable<Agendamento> BuscarProximosAgendamentosCliente(int prestadorId)
        {
            return agendamentoRepository.BuscarProximosAgendamentos(prestadorId, TipoUsuario.CLIENTE);
        }

        public IEnumerable<Agendamento> BuscarProximosAgendamentosPrestador(int prestadorId)
        {
            return agendamentoRepository.BuscarProximosAgendamentos(prestadorId, TipoUsuario.PRESTADOR);
        }

        void IAgendamentoService.Cancelar(int agendamentoId)
        {
            agendamentoRepository.Cancelar(agendamentoId);
        }
    }
}
