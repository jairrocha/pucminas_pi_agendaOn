namespace AgendaOn.Domain.Entities
{
    public class Administrador:EntityBase
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
