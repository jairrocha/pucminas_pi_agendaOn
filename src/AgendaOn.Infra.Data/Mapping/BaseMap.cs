using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AgendaOn.Domain.Entities;

namespace AgendaOn.Infra.Data.Mapping
{
    public class BaseMap<T> : IEntityTypeConfiguration<T>
        where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {

            builder.HasKey(c => c.Id);
           
        }
    }
}
