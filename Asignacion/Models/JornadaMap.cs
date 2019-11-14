using Asignacion.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asignacion.Models
{
    public class JornadaMap : IEntityTypeConfiguration<Jornada>
    {
        public void Configure(EntityTypeBuilder<Jornada> builder)
        {
            builder.ToTable("Jornada")
               .HasKey(c => c.idjornada);
            builder.Property(c => c.descripcion)
                .HasMaxLength(100);
        }
    }
}
