using Asignacion.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asignacion.Models
{
    public class GrupoMap : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.ToTable("Grupo")
               .HasKey(c => c.idgrupo);
            builder.ToTable("Grupo")
               .HasIndex(c => c.descripcion)
               .IsUnique();
            builder.Property(c => c.descripcion)
                .HasMaxLength(50);
        }
    }
}
