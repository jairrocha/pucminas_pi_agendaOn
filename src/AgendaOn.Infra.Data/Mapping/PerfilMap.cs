using AgendaOn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaOn.Infra.Data.Mapping
{
    public class PerfilMap: BaseMap<Perfil>
    {
        public override void Configure(EntityTypeBuilder<Perfil> builder)
        {
            base.Configure(builder);

            builder
                .ToTable("TB_PERFIL");

            builder.Property(p => p.Id).HasColumnName("ID_PERFIL");
            builder.Property(p => p.Descricao).HasColumnName("DESCRICAO").IsUnicode(false);
            builder.Property(p => p.PrestadorId).HasColumnName("ID_PRESTADOR");

            builder.HasOne(p => p.Prestador)
                .WithOne(pre => pre.Perfil)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
