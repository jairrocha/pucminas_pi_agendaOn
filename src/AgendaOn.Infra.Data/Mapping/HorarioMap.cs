using AgendaOn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaOn.Infra.Data.Mapping
{
    public class HorarioMap : BaseMap<Horario>
    {
        public override void Configure(EntityTypeBuilder<Horario> builder)
        {
            base.Configure(builder);

            builder
                .ToTable("TB_HORARIO");

            builder.Property(a => a.Id).HasColumnName("ID_HORARIO");
            builder.Property(a => a.PrestadorId).HasColumnName("ID_PRESTADOR").IsRequired();
            builder.Property(a => a.HoraInicio).HasColumnName("HORA_INICIO").IsRequired();
            builder.Property(a => a.HoraFim).HasColumnName("HORA_FIM").IsRequired();


        }
    }
}
