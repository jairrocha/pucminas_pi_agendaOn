using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaOn.Domain.Entities
{
    public class Avaliacao: EntityBase
    {
        public int Nota { get; set; }
        public string DescAvaliacao { get; set; }
        public int PerfilId { get; set; }
        public int ClienteId { get; set; }
        public Perfil Perfil { get; set; }
        public Cliente Cliente { get; set; }
    }
}
