using Asignacion.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asignacion.Models
{
    public class RolMap : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Rol")
               .HasKey(c => c.idrol);
            builder.Property(c => c.descripcion)
                .HasMaxLength(50);
        }
    }
}
