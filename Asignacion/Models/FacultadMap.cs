using Asignacion.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asignacion.Models
{
    public class FacultadMap : IEntityTypeConfiguration<Facultad>
    {
        public void Configure(EntityTypeBuilder<Facultad> builder)
        {
            builder.ToTable("Facultad")
               .HasKey(c => c.idfacultad);
            builder.Property(c => c.descripcion)
                .HasMaxLength(100);
        }
    }
}
