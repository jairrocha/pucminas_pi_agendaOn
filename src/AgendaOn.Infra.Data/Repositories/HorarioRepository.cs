using AgendaOn.Domain.Entities;
using AgendaOn.Domain.Interfaces.Repositories;
using AgendaOn.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaOn.Infra.Data.Repositories
{
    public class HorarioRepository : RepositoryBase<Horario>, IHorarioRepository
    {
        public HorarioRepository(AgendaOnContext contexto) : base(contexto)
        {
        }
    }
}
