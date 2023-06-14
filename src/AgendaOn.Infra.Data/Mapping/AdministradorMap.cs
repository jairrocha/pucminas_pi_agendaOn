using AgendaOn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaOn.Infra.Data.Mapping
{
    public class AdministradorMap : BaseMap<Administrador>
    {
        public override void Configure(EntityTypeBuilder<Administrador> builder)
        {
            base.Configure(builder);

            builder
                .ToTable("TB_ADMINISTRADOR");

            builder.Property(a => a.Id).HasColumnName("ID_ADMINISTRADOR");
            builder.Property(a => a.UsuarioId).HasColumnName("ID_USUARIO");

        }
    }
}
