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
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<DiaSemana> DiaSemanas { get; set; }
        public DbSet<Facultad> Facultades { get; set; }
        public DbSet<Jornada> Jornadas { get; set; }
        public DbSet<Modalidad> Modalidades { get; set; }
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Sede> Sedes { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<GrupoAula> GrupoAulas { get; set; }
        public DbSet<Programa> Programas { get; set; }
        public DbSet<ProgramaAsignatura> ProgramaAsignaturas { get; set; }

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
            modelBuilder.ApplyConfiguration(new AulaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new GrupoMap());
            modelBuilder.ApplyConfiguration(new AsignaturaMap());
            modelBuilder.ApplyConfiguration(new HorarioMap());
            modelBuilder.ApplyConfiguration(new GrupoAulaMap());
            modelBuilder.ApplyConfiguration(new ProgramaMap());
            modelBuilder.ApplyConfiguration(new ProgramaAsignaturaMap());
        }
    }
}
