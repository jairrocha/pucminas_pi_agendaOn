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
                new Horario() { Prestador = prestador, HoraInicio =new TimeOnly(9,0), HoraFim = new TimeOnly(9,45)},
                new Horario() { Prestador = prestador, HoraInicio =new TimeOnly(10,0), HoraFim = new TimeOnly(10,45)},
                new Horario() { Prestador = prestador, HoraInicio =new TimeOnly(11,0), HoraFim = new TimeOnly(11,45)},
                new Horario() { Prestador = prestador, HoraInicio =new TimeOnly(13,0), HoraFim = new TimeOnly(13,45)},
                new Horario() { Prestador = prestador, HoraInicio =new TimeOnly(14,0), HoraFim = new TimeOnly(14,45)},
                new Horario() { Prestador = prestador, HoraInicio =new TimeOnly(15,0), HoraFim = new TimeOnly(15,45)},
                new Horario() { Prestador = prestador, HoraInicio =new TimeOnly(16,0), HoraFim = new TimeOnly(16,45)},
                new Horario() { Prestador = prestador, HoraInicio =new TimeOnly(17,0), HoraFim = new TimeOnly(17,45)}
            };

            foreach (var horario in horarios)
            {
                _horarioRepository.Incluir(horario);
            }
            
        }
    }
    }
