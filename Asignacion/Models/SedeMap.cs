using Asignacion.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asignacion.Models
{
    public class SedeMap : IEntityTypeConfiguration<Sede>
    {
        public void Configure(EntityTypeBuilder<Sede> builder)
        {
            builder.ToTable("Sede")
               .HasKey(c => c.idsede);
            builder.Property(c => c.descripcion)
                .HasMaxLength(50);
        }
    }
}
