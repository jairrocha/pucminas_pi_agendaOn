using AgendaOn.Domain.Entities;
using AgendaOn.Domain.Enums;
using AgendaOn.Domain.Interfaces.Repositories;
using AgendaOn.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AgendaOn.Infra.Data.Repositories
{
    public class AgendamentoRepository : RepositoryBase<Agendamento>, IAgendamentoRepository
    {
        public AgendamentoRepository(AgendaOnContext contexto) : base(contexto) { }

        public void Agendar(int clienteId, int prestadorId, int agendaId, DateTime date)
        {
            Incluir(new Agendamento()
            {
                ClienteId = clienteId,
                PrestadorId = prestadorId,
                HorarioId = agendaId,
                DataAgendamento = date
            });
        }

        public IEnumerable<Agendamento> BuscarAgendamentoPorData(int Id, DateTime data, TipoUsuario tipoUsuario)
        {

            if (tipoUsuario.Equals(TipoUsuario.PRESTADOR))
            {
                return _contexto.Agendamentos
                  .Where(_ => _.PrestadorId.Equals(Id) &&
                  _.DataAgendamento.Date.Equals(data.Date) && !_.DataCancelamento.HasValue)
                  .Include(_ => _.Horario)
                  .Include(_ => _.Cliente.Usuario)
                  .ToList();
            }
            else if (tipoUsuario.Equals(TipoUsuario.CLIENTE))
            {

                var result = _contexto.Agendamentos
                    .Where(_ => _.ClienteId.Equals(Id) &&
                    _.DataAgendamento.Date.Equals(data.Date) && !_.DataCancelamento.HasValue)
                    .Include(_ => _.Horario)
                    .Include(_ => _.Prestador.Usuario)
                    .ToList();

                return result;
            }


            return new List<Agendamento>();

        }

        public IEnumerable<Agendamento> BuscarProximosAgendamentos(int id, TipoUsuario tipoUsuario)
        {
            if (tipoUsuario.Equals(TipoUsuario.PRESTADOR))
            {
                return _contexto.Agendamentos
                    .Where(_ => _.PrestadorId.Equals(id) && _.DataAgendamento >= DateTime.Now.Date && 
                                                                        !_.DataCancelamento.HasValue)
                    .Include(_=>_.Cliente.Usuario)
                    .Include(_ => _.Horario)
                    .ToList();
            }
            else if (tipoUsuario.Equals(TipoUsuario.CLIENTE))
            {
                return _contexto.Agendamentos
                    .Where(_ => _.ClienteId.Equals(id) && _.DataAgendamento >= DateTime.Now.Date && 
                                                                        !_.DataCancelamento.HasValue)
                    .Include(_ => _.Prestador.Usuario)
                    .Include(_ => _.Horario)
                    .ToList();
            }

            return new List<Agendamento>();

        }



        public void Cancelar(int agendamentoId)
        {
            var agendamento = this.SelecionarPorId(agendamentoId);

            if (agendamento != null)
            {
                agendamento.DataCancelamento = DateTime.Now;
                Alterar(agendamento);
            }

        }
    }


}
