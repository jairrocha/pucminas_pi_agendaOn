using AgendaOn.Domain.Entities;
using AgendaOn.Domain.Interfaces.Repositories;
using AgendaOn.Infra.Data.Contexts;

namespace AgendaOn.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(AgendaOnContext contexto) : base(contexto)
        {

        }

    
    }
}
