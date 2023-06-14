using AgendaOn.Domain.Enums;

namespace AgendaOn.Domain.Entities
{
    public class Horario: EntityBase
    {
       public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFim { get; set; }
        public int PrestadorId { get; set; }
        public Prestador Prestador { get; set; }
        public IEnumerable<Agendamento> Agendamentos { get; set; }


    }
}
