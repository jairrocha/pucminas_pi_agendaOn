namespace AgendaOn.Domain.Entities
{
    public class Prestador: EntityBase
    {
        
        public int UsuarioId { get; set; }
        public decimal Preco { get; set; }
        public Usuario Usuario { get; set; }
        public Perfil Perfil { get; set; }
        public IEnumerable<Horario> Horarios { get; set; }
        public IEnumerable<Agendamento> Agendamentos { get; set; }
        
    }
}