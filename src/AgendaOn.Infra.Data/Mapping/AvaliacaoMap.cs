using AgendaOn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaOn.Infra.Data.Mapping
{
    public class AvaliacaoMap:BaseMap<Avaliacao>
    {
        public override void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            base.Configure(builder);

            builder
                .ToTable("TB_AVALIACAO");

            builder.Property(a => a.Id).HasColumnName("ID_AVALIACAO");
            builder.Property(a => a.Nota).HasColumnName("NOTA").IsRequired();
            builder.Property(a => a.DescAvaliacao).HasColumnName("DESC_AVALIACAO")
                .IsUnicode(false).HasMaxLength(100).IsRequired(false);
            builder.Property(a => a.PerfilId).HasColumnName("ID_PERFIL").IsRequired();
            builder.Property(a => a.ClienteId).HasColumnName("ID_CLIENTE").IsRequired();

            builder.HasOne(a => a.Perfil)
                .WithMany(p => p.Avaliacoes)
                .HasForeignKey(a => a.PerfilId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Cliente)
                .WithMany(c => c.Avaliacoes)
                .HasForeignKey(a => a.ClienteId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
