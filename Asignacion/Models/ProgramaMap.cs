using Asignacion.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asignacion.Models
{
    public class ProgramaMap : IEntityTypeConfiguration<Programa>
    {
        public void Configure(EntityTypeBuilder<Programa> builder)
        {
            builder.ToTable("Programa")
               .HasKey(c => c.idprograma);
            builder.ToTable("Programa")
               .HasOne(p => p.facultad)
               .WithMany(b => b.programa)
               .HasForeignKey(p => p.idfacultad);
            builder.ToTable("Programa")
               .HasOne(p => p.jornada)
               .WithMany(b => b.programa)
               .HasForeignKey(p => p.idjornada);
            builder.Property(c => c.descripcion)
                .HasMaxLength(50);
        }
    }
}
