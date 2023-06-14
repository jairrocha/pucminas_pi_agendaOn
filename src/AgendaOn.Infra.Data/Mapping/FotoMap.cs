using AgendaOn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaOn.Infra.Data.Mapping
{
    public class FotoMap:BaseMap<Foto>
    {
        public override void Configure(EntityTypeBuilder<Foto> builder)
        {
            base.Configure(builder);

            builder
                .ToTable("TB_FOTO");

            builder.Property(f => f.Id).HasColumnName("ID_FOTO");
            builder.Property(f => f.Path).HasColumnName("PATH").IsUnicode(false);
            builder.Property(f => f.PerfilId).HasColumnName("ID_PERFIL");

            builder.HasOne(f => f.Perfil)
                .WithMany(p => p.Fotos)
                .HasForeignKey(p => p.PerfilId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
