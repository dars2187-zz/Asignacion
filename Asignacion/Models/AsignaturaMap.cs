using Asignacion.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asignacion.Models
{
    public class AsignaturaMap : IEntityTypeConfiguration<Asignatura>
    {
        public void Configure(EntityTypeBuilder<Asignatura> builder)
        {
            builder.ToTable("Asignatura")
               .HasKey(c => c.idasignatura);
            builder.Property(c => c.descripcion)
                .HasMaxLength(50);
        }
    }
}
