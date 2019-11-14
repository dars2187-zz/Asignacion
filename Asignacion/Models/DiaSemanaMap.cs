using Asignacion.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asignacion.Models
{
    public class DiaSemanaMap : IEntityTypeConfiguration<DiaSemana>
    {
        public void Configure(EntityTypeBuilder<DiaSemana> builder)
        {
            builder.ToTable("DiaSemana")
               .HasKey(c => c.iddiasemana);
            builder.Property(c => c.descripcion)
                .HasMaxLength(10);
        }
    }
}
