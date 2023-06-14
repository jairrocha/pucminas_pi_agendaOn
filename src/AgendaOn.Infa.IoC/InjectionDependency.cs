using AgendaOn.Application;
using AgendaOn.Domain.Interfaces.Repositories;
using AgendaOn.Domain.Interfaces.Services;
using AgendaOn.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AgendaOn.Infa.IoC
{
    public static class InjectionDependency
    {
        public static void Register(this IServiceCollection svcCollection)
        {
            //Serviços
            svcCollection.AddScoped<IAgendamentoService, AgendamentoService>();
            svcCollection.AddScoped<IClienteService, ClienteService>();
            svcCollection.AddScoped<IPrestadorService, PrestadorService>();
            svcCollection.AddScoped<IUsuarioService, UsuarioService>();
            svcCollection.AddScoped<IHorarioService, HorarioService>();


            //Repositorios
            svcCollection.AddScoped(typeof(IBaseRepository<>), typeof(RepositoryBase<>));
            svcCollection.AddScoped<IHorarioRepository, HorarioRepository>();
            svcCollection.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
            svcCollection.AddScoped<IClienteRepository, ClienteRepository>();
            svcCollection.AddScoped<IPrestadorRepository, PrestadorRepository>();
            svcCollection.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
            svcCollection.AddScoped<IUsuarioRepository, UsuarioRepository>();

        }

    }
}
