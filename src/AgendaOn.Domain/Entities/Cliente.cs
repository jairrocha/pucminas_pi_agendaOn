namespace AgendaOn.Domain.Entities
{
    public class Cliente: EntityBase
    {
       
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public IEnumerable<Agendamento> Agendamentos { get; set; }
        public IEnumerable<Avaliacao> Avaliacoes { get; set; }
        
    }
}
