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
            builder.Property(c => c.descripcion)
                .HasMaxLength(50);
        }
    }
}
