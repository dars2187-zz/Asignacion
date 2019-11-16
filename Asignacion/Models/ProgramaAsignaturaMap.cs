using Asignacion.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asignacion.Models
{
    public class ProgramaAsignaturaMap : IEntityTypeConfiguration<ProgramaAsignatura>
    {
        public void Configure(EntityTypeBuilder<ProgramaAsignatura> builder)
        {
            builder.ToTable("ProgramaAsignatura")
               .HasKey(c => new { c.idprograma, c.idasignatura });
            builder.ToTable("ProgramaAsignatura")
               .HasOne(c => c.programa)
               .WithMany(b => b.programaasignaturas)
               .HasForeignKey(a => a.idprograma);
            builder.ToTable("ProgramaAsignatura")
               .HasOne(c => c.asignatura)
               .WithMany(b => b.programaasignaturas)
               .HasForeignKey(a => a.idasignatura);
        }
    }
}
