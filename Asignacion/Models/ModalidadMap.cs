using Asignacion.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asignacion.Models
{
    public class ModalidadMap : IEntityTypeConfiguration<Modalidad>
    {
        public void Configure(EntityTypeBuilder<Modalidad> builder)
        {
            builder.ToTable("Modalidad")
               .HasKey(c => c.idmodalidad);
            builder.Property(c => c.descripcion)
                .HasMaxLength(50);
        }
    }
}
