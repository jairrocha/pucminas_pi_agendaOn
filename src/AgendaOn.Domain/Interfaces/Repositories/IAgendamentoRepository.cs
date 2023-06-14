using AgendaOn.Domain.Entities;
using AgendaOn.Domain.Enums;

namespace AgendaOn.Domain.Interfaces.Repositories
{
    public interface IAgendamentoRepository : IBaseRepository<Agendamento>
    {
        void Agendar(int clienteId, int PrestadorId, int agendaId, DateTime date);
        void Cancelar(int agendamentoId);
        IEnumerable<Agendamento> BuscarAgendamentoPorData(int Id, DateTime data, TipoUsuario tipoUsuario);
        IEnumerable<Agendamento> BuscarProximosAgendamentos(int id, TipoUsuario tipoUsuario);


    }
}
