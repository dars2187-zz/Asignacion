using Asignacion.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asignacion.Models
{
    public class DbContextAsignacion : DbContext
    {
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<DiaSemana> DiaSemana { get; set; }
        public DbSet<Facultad> Facultad { get; set; }
        public DbSet<Jornada> Jornada { get; set; }
        public DbSet<Modalidad> Modalidad { get; set; }
        public DbSet<Parametro> Parametro { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Sede> Sede { get; set; }
        public DbContextAsignacion(DbContextOptions<DbContextAsignacion> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TipoDocumentoMap());
            modelBuilder.ApplyConfiguration(new DiaSemanaMap());
            modelBuilder.ApplyConfiguration(new FacultadMap());
            modelBuilder.ApplyConfiguration(new JornadaMap());
            modelBuilder.ApplyConfiguration(new ModalidadMap());
            modelBuilder.ApplyConfiguration(new ParametroMap());
            modelBuilder.ApplyConfiguration(new RolMap());
            modelBuilder.ApplyConfiguration(new SedeMap());
        }
    }
}
