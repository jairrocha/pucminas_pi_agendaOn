using AgendaOn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaOn.Infra.Data.Mapping
{
    public class UsuarioMap : BaseMap<Usuario>
    {
        public override void Configure(EntityTypeBuilder<Usuario> builder)
        {
            base.Configure(builder);

            builder
                .ToTable("TB_USUARIO");

            builder.Property(u => u.Id)
                .HasColumnName("ID_USUARIO");


            builder.Property(u => u.IdIdentity)
                .HasColumnName("ID_IDENTITY");


            builder.Property(u => u.Nome)
                .HasColumnName("NOME")
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .HasColumnName("EMAIL")
                .IsUnicode(true)
                .IsRequired()
                .HasMaxLength(255);

                       

            // Index the code column, unique
            builder.HasIndex(u => u.IdIdentity)
                .IsUnique();


        }

    }
}
