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
            builder.ToTable("Asignatura")
               .HasOne(p => p.modalidad)
               .WithMany(b => b.asignatura)
               .HasForeignKey(p => p.idmodalidad);
            builder.Property(c => c.descripcion)
                .HasMaxLength(50);
        }
    }
}
