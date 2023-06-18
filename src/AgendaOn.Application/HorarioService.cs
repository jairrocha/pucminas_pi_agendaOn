using AgendaOn.Domain.Entities;
using AgendaOn.Domain.Interfaces.Repositories;
using AgendaOn.Domain.Interfaces.Services;

namespace AgendaOn.Application
{
    public class HorarioService : IHorarioService
    {
        private IHorarioRepository _horarioRepository;

        public HorarioService(IHorarioRepository horarioRepository)
        {
            _horarioRepository = horarioRepository;
        }

        public void DenifinirAgendaPadrao(Prestador prestador)
        {
            var horarios = new List<Horario>()
            {
                new Horario() { Prestador = prestador, HoraInicio =new TimeSpan(9,0,0), HoraFim = new TimeSpan(9,45,0)},
                new Horario() { Prestador = prestador, HoraInicio =new TimeSpan(10,0,0), HoraFim = new TimeSpan(10,45,0)},
                new Horario() { Prestador = prestador, HoraInicio =new TimeSpan(11,0,0), HoraFim = new TimeSpan(11,45,0)},
                new Horario() { Prestador = prestador, HoraInicio =new TimeSpan(13,0,0), HoraFim = new TimeSpan(13,45,0)},
                new Horario() { Prestador = prestador, HoraInicio =new TimeSpan(14,0,0), HoraFim = new TimeSpan(14,45,0)},
                new Horario() { Prestador = prestador, HoraInicio =new TimeSpan(15,0,0), HoraFim = new TimeSpan(15,45,0)},
                new Horario() { Prestador = prestador, HoraInicio =new TimeSpan(16,0,0), HoraFim = new TimeSpan(16,45,0)},
                new Horario() { Prestador = prestador, HoraInicio =new TimeSpan(17,0,0), HoraFim = new TimeSpan(17,45,0)}
            };

            foreach (var horario in horarios)
            {
                _horarioRepository.Incluir(horario);
            }
            
        }
    }
    }
