using Asignacion.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asignacion.Models
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario")
               .HasKey(c => c.idusuario);
            builder.Property(c => c.numdocumento)
                .HasMaxLength(10);
            builder.Property(c => c.nombre)
                .HasMaxLength(100);
            builder.Property(c => c.apellido)
                .HasMaxLength(100);
            builder.Property(c => c.numdocumento)
                .HasMaxLength(50);
        }
    }
}
