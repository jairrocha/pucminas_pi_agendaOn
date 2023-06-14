using AgendaOn.Domain.Entities;
using AgendaOn.Domain.Interfaces.Repositories;
using AgendaOn.Infra.Data.Contexts;

namespace AgendaOn.Infra.Data.Repositories
{
    public class AvaliacaoRepository : RepositoryBase<Avaliacao>, IAvaliacaoRepository
    {
        public AvaliacaoRepository(AgendaOnContext contexto) : base(contexto)
        {
        }
    }
}
