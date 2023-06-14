namespace AgendaOn.Domain.Entities
{
    public class Perfil: EntityBase
    {
        public string Descricao { get; set; }
        public int PrestadorId { get; set; }
        public  Prestador Prestador { get; set; }
        public IEnumerable<Avaliacao> Avaliacoes { get; set; }
        public IEnumerable<RedeSocial> RedeSociais { get; set; }
        public IEnumerable<Foto> Fotos { get; set; }
    }
}
