using AgendaOn.Domain.Entities;
using AgendaOn.Domain.Interfaces.Repositories;
using AgendaOn.Infra.Data.Contexts;
using AgendaOn.Infra.Data.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AgendaOn.Infra.Data.Repositories
{
    public class RepositoryBase<TEntidade> : IBaseRepository<TEntidade>
        where TEntidade : EntityBase
    {
        protected readonly AgendaOnContext _contexto;

        public RepositoryBase(AgendaOnContext contexto) : base()
        {
            _contexto = contexto;
        }

        public void Alterar(TEntidade entidade)
        {

            if (_contexto.Set<TEntidade>().Attach(entidade).GetDatabaseValues() == null)
            {
                throw new EntityNotFoundException();
            }

            _contexto.InitTransacao();
            _contexto.Entry(entidade).State = EntityState.Modified;
            _contexto.SendChanges();

        }

        public void Excluir(int Id)
        {
            var entidade = SelecionarPorId(Id);
            if (entidade == null)
            {
                throw new EntityNotFoundException();
            }
            
            _contexto.InitTransacao();
            _contexto.Set<TEntidade>().Remove(entidade);
            _contexto.SendChanges();

        }

        public void Excluir(TEntidade entidade)
        {
          
            if (SelecionarPorId(entidade.Id) == null)
            {
                throw new EntityNotFoundException();
            }

            _contexto.InitTransacao();
            _contexto.Set<TEntidade>().Remove(entidade);
            _contexto.SendChanges();

        }

        public int Incluir(TEntidade entidade)
        {
            _contexto.InitTransacao();
            _contexto.Set<TEntidade>().Add(entidade);
            _contexto.SendChanges();
            return entidade.Id;
        }

        public void Incluir(IEnumerable<TEntidade> entidade)
        {
            _contexto.InitTransacao();
            _contexto.Set<TEntidade>().AddRange(entidade);
            _contexto.SendChanges();
            
        }

        public TEntidade SelecionarPorId(int Id)
        {
            return _contexto.Set<TEntidade>().Find(Id);
        }


    }
}
