using AgendaOn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaOn.Infra.Data.Mapping
{
    public class AgendamentoMap : BaseMap<Agendamento>
    {
        public override void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            base.Configure(builder);

            builder
                .ToTable("TB_AGENDAMENTO");

            builder.Property(a => a.Id).HasColumnName("ID_AGENDAMENTO");
            builder.Property(a => a.ClienteId).HasColumnName("ID_CLIENTE").IsRequired();
            builder.Property(a => a.PrestadorId).HasColumnName("ID_PRESTADOR").IsRequired();
            builder.Property(a => a.HorarioId).HasColumnName("ID_HORARIO").IsRequired();
            builder.Property(a => a.DataAgendamento).HasColumnName("DT_AGENDAMENTO").IsRequired();
            builder.Property(a => a.DataCancelamento).HasColumnName("DT_CANCELAMENTO").IsRequired(false);


            builder.HasOne(a => a.Horario)
                .WithMany(h => h.Agendamentos)
                .HasForeignKey(a => a.HorarioId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Cliente)
                .WithMany(P => P.Agendamentos)
                .HasForeignKey(a => a.ClienteId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Prestador)
                .WithMany(h => h.Agendamentos)
                .HasForeignKey(a => a.PrestadorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
