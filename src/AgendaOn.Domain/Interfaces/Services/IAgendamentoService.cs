using AgendaOn.Domain.Entities;

namespace AgendaOn.Domain.Interfaces.Services
{
    public interface IAgendamentoService
    {
        void Agendar(int clienteId, int PrestadorId, int agendaId, DateTime date);
        void Cancelar(int agendamentoId);
        void Alterar(int agendamentoId, int horarioId, DateTime date);
        
        IEnumerable<Horario> BuscarHorariosDisponiveisPrestador(int prestadorId, DateTime date);
        IEnumerable<Agendamento> BuscarAgendamentoPrestadorPorData(int prestadorId, DateTime data);
        IEnumerable<Agendamento> BuscarProximosAgendamentosPrestador(int prestadorId);
       
        IEnumerable<Agendamento> BuscarAgendamentoClientePorData(int ClienteId, DateTime data);
        IEnumerable<Agendamento> BuscarProximosAgendamentosCliente(int prestadorId);

    }
}
