using AgendaOn.Domain.Enums;

namespace AgendaOn.Domain.Entities
{
    public class Horario: EntityBase
    {
       public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public int PrestadorId { get; set; }
        public Prestador Prestador { get; set; }
        public IEnumerable<Agendamento> Agendamentos { get; set; }


    }
}
