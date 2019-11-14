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
        public DbContextAsignacion(DbContextOptions<DbContextAsignacion> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TipoDocumentoMap());
        }
    }
}
