namespace AgendaOn.Domain.Entities
{
    public class RedeSocial:EntityBase
    {
        public string Rede { get; set; }
        public string Link { get; set; }
        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }
    }
}
