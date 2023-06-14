using AgendaOn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaOn.Infra.Data.Mapping
{
    public class RedeSocialMap : BaseMap<RedeSocial>
    {
        public override void Configure(EntityTypeBuilder<RedeSocial> builder)
        {
            base.Configure(builder);

            builder
                .ToTable("TB_REDE_SOCIAL");

            builder.Property(r => r.Id).HasColumnName("ID_REDE_SOCIAL");
            builder.Property(r => r.Rede).HasColumnName("NOME_REDE").IsUnicode(false);
            builder.Property(r => r.Link).HasColumnName("LINK").IsUnicode(false);
            builder.Property(r => r.PerfilId).HasColumnName("ID_PERFIL");

            builder.HasOne(r => r.Perfil)
                .WithMany(p => p.RedeSociais)
                .HasForeignKey(p => p.PerfilId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
