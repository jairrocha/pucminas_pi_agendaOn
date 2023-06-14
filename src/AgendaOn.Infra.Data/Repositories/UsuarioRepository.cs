using AgendaOn.Domain.Entities;
using AgendaOn.Domain.Enums;
using AgendaOn.Domain.Interfaces.Repositories;
using AgendaOn.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AgendaOn.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AgendaOnContext contexto) : base(contexto)
        {
        }

        public Usuario? BuscarUsuario(string id)
        {
            return _contexto.Usuarios
                .Where(_ => _.IdIdentity.Equals(id))
                .Include(_ => _.Cliente)
                .Include(_ => _.Prestador)
                .FirstOrDefault();

        }

        public Usuario? Cadastrar(string nome, string email, string IdIdentity)
        {

            try
            {

                var id = Incluir(new Usuario()
                {

                    IdIdentity = IdIdentity,
                    Nome = nome,
                    Email = email

                });

                return SelecionarPorId(id);


            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Cadastrar usuário", ex) ;
            }

  
        }
    }
}
