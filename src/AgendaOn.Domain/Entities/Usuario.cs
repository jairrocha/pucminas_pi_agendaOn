namespace AgendaOn.Domain.Entities
{
    public class Usuario: EntityBase
    {
        public string IdIdentity { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Cliente? Cliente { get; set; }
        public Prestador? Prestador { get; set; }
        public Administrador? Administrador { get; set; }



    }
}
