using Asignacion.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asignacion.Models
{
    public class ParametroMap : IEntityTypeConfiguration<Parametro>
    {
        public void Configure(EntityTypeBuilder<Parametro> builder)
        {
            builder.ToTable("Parametro")
               .HasKey(c => c.idparametro);
            builder.Property(c => c.descripcion)
                .HasMaxLength(50);
            builder.Property(c => c.valor)
                .HasMaxLength(50);
        }
    }
}
