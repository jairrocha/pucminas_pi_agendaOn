namespace AgendaOn.Domain.Entities
{
    public class Foto:EntityBase
    {
        public string Path { get; set; }
        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }
    }
}
