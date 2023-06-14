using AgendaOn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaOn.Infra.Data.Mapping
{
    public class ClienteMap:BaseMap<Cliente>
    {
        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            base.Configure(builder);

            builder
                .ToTable("TB_CLIENTE");

            builder.Property(c => c.Id).HasColumnName("ID_CLIENTE");
            builder.Property(c => c.UsuarioId).HasColumnName("ID_USUARIO");

        }
    }
}
