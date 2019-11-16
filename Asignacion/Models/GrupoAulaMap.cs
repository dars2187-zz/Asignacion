using Asignacion.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asignacion.Models
{
    public class GrupoAulaMap : IEntityTypeConfiguration<GrupoAula>
    {
        public void Configure(EntityTypeBuilder<GrupoAula> builder)
        {
            builder.ToTable("GrupoAula")
               .HasKey(c => new { c.idgrupo, c.idaula });
            builder.ToTable("GrupoAula")
               .HasOne(c => c.aula)
               .WithMany(b => b.grupoaulas)
               .HasForeignKey(a => a.idaula);
            builder.ToTable("GrupoAula")
               .HasOne(c => c.grupo)
               .WithMany(b => b.grupoaulas)
               .HasForeignKey(a => a.idgrupo);
        }
    }
}
