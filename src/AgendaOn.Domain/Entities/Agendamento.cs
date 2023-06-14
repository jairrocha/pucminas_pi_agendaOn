using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaOn.Domain.Entities
{
    public class Agendamento : EntityBase
    {
        public int ClienteId { get; set; }
        public int PrestadorId { get; set; }
        public int HorarioId { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public Cliente Cliente { get; set; }
        public Prestador Prestador { get; set; }
        public Horario Horario { get; set; }
    }
}
