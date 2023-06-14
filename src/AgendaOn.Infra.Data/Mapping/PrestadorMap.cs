using AgendaOn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaOn.Infra.Data.Mapping
{
    public class PrestadorMap:BaseMap<Prestador>
    {
        public override void Configure(EntityTypeBuilder<Prestador> builder)
        {
            base.Configure(builder);

            builder
                .ToTable("TB_PRESTADOR");

            builder.Property(p => p.Id).HasColumnName("ID_PRESTADOR");
            builder.Property(p => p.Preco).HasColumnName("PRECO").IsRequired().HasDefaultValue(100);
            builder.Property(c => c.UsuarioId).HasColumnName("ID_USUARIO");


        }
    }
}
