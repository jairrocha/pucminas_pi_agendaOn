using AgendaOn.Domain.Entities;
using AgendaOn.Domain.Interfaces.Repositories;
using AgendaOn.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AgendaOn.Infra.Data.Repositories
{
    public class PrestadorRepository : RepositoryBase<Prestador>, IPrestadorRepository
    {
        public PrestadorRepository(AgendaOnContext contexto) : base(contexto){}

     
        public Prestador? SelecionarPorId(int id)
        {
            return _contexto.Prestadores
                .Where(_ => _.Id.Equals(id))
                .Include(_=>_.Horarios)
                .FirstOrDefault();
        }
           
        public IEnumerable<Prestador> SelecionarPorNome(string nome)
        {
            
            return  _contexto.Prestadores.Where(_ => _.Usuario.Nome.Equals(nome))
                        .Include(_ => _.Perfil)
                        .Include(_ => _.Perfil.Avaliacoes)
                        .Include(_ => _.Horarios)
                        .Include(_ => _.Agendamentos)
                        .ToList();
        }

        public IEnumerable<Prestador> SelecionarTodos()
        {
            return _contexto.Prestadores
                  .Include(_ => _.Perfil)
                  .Include(_ => _.Perfil.Avaliacoes)
                  .Include(_ => _.Horarios)
                  .Include(_ => _.Agendamentos)
                  .Include(_ => _.Usuario)
                  .ToList();
        }
    }
}
    