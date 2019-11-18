﻿// <auto-generated />
using System;
using Asignacion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Asignacion.Migrations
{
    [DbContext(typeof(DbContextAsignacion))]
    [Migration("20191118073253_AjustesPrograma")]
    partial class AjustesPrograma
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Asignacion.Entidades.Asignatura", b =>
                {
                    b.Property<int>("idasignatura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("credito")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("idmodalidad")
                        .HasColumnType("int");

                    b.HasKey("idasignatura");

                    b.HasIndex("idmodalidad");

                    b.ToTable("Asignatura");
                });

            modelBuilder.Entity("Asignacion.Entidades.Aula", b =>
                {
                    b.Property<int>("idaula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idsede")
                        .HasColumnType("int");

                    b.Property<string>("numaula")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("idaula");

                    b.ToTable("Aula");
                });

            modelBuilder.Entity("Asignacion.Entidades.DiaSemana", b =>
                {
                    b.Property<int>("iddiasemana")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("iddiasemana");

                    b.ToTable("DiaSemana");
                });

            modelBuilder.Entity("Asignacion.Entidades.Facultad", b =>
                {
                    b.Property<int>("idfacultad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("idfacultad");

                    b.ToTable("Facultad");
                });

            modelBuilder.Entity("Asignacion.Entidades.Grupo", b =>
                {
                    b.Property<int>("idgrupo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("idasignatura")
                        .HasColumnType("int");

                    b.Property<int>("idhorario")
                        .HasColumnType("int");

                    b.HasKey("idgrupo");

                    b.HasIndex("descripcion")
                        .IsUnique();

                    b.ToTable("Grupo");
                });

            modelBuilder.Entity("Asignacion.Entidades.GrupoAula", b =>
                {
                    b.Property<int>("idgrupo")
                        .HasColumnType("int");

                    b.Property<int>("idaula")
                        .HasColumnType("int");

                    b.HasKey("idgrupo", "idaula");

                    b.HasIndex("idaula");

                    b.ToTable("GrupoAula");
                });

            modelBuilder.Entity("Asignacion.Entidades.Horario", b =>
                {
                    b.Property<int>("idhorario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Grupoidgrupo")
                        .HasColumnType("int");

                    b.Property<int?>("diasemanaiddiasemana")
                        .HasColumnType("int");

                    b.Property<string>("horafin")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("horainicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<int>("iddiasemana")
                        .HasColumnType("int");

                    b.HasKey("idhorario");

                    b.HasIndex("Grupoidgrupo");

                    b.HasIndex("diasemanaiddiasemana");

                    b.ToTable("Horario");
                });

            modelBuilder.Entity("Asignacion.Entidades.Jornada", b =>
                {
                    b.Property<int>("idjornada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("idjornada");

                    b.ToTable("Jornada");
                });

            modelBuilder.Entity("Asignacion.Entidades.Modalidad", b =>
                {
                    b.Property<int>("idmodalidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("idmodalidad");

                    b.ToTable("Modalidad");
                });

            modelBuilder.Entity("Asignacion.Entidades.Parametro", b =>
                {
                    b.Property<int>("idparametro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("valor")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("idparametro");

                    b.ToTable("Parametro");
                });

            modelBuilder.Entity("Asignacion.Entidades.Programa", b =>
                {
                    b.Property<int>("idprograma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Usuarioidusuario")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("idfacultad")
                        .HasColumnType("int");

                    b.Property<int>("idjornada")
                        .HasColumnType("int");

                    b.HasKey("idprograma");

                    b.HasIndex("Usuarioidusuario");

                    b.HasIndex("idfacultad");

                    b.HasIndex("idjornada");

                    b.ToTable("Programa");
                });

            modelBuilder.Entity("Asignacion.Entidades.ProgramaAsignatura", b =>
                {
                    b.Property<int>("idprograma")
                        .HasColumnType("int");

                    b.Property<int>("idasignatura")
                        .HasColumnType("int");

                    b.HasKey("idprograma", "idasignatura");

                    b.HasIndex("idasignatura");

                    b.ToTable("ProgramaAsignatura");
                });

            modelBuilder.Entity("Asignacion.Entidades.Rol", b =>
                {
                    b.Property<int>("idrol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("idrol");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("Asignacion.Entidades.Sede", b =>
                {
                    b.Property<int>("idsede")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Aulaidaula")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("idsede");

                    b.HasIndex("Aulaidaula");

                    b.ToTable("Sede");
                });

            modelBuilder.Entity("Asignacion.Entidades.TipoDocumento", b =>
                {
                    b.Property<int>("idtipodocumento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("idtipodocumento");

                    b.ToTable("TipoDocumento");
                });

            modelBuilder.Entity("Asignacion.Entidades.Usuario", b =>
                {
                    b.Property<int>("idusuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("clave")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<int>("idprograma")
                        .HasColumnType("int");

                    b.Property<int>("idrol")
                        .HasColumnType("int");

                    b.Property<int>("idtipodocumento")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("numdocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("rolidrol")
                        .HasColumnType("int");

                    b.Property<int>("telefono")
                        .HasColumnType("int");

                    b.Property<int?>("tipodocumentoidtipodocumento")
                        .HasColumnType("int");

                    b.HasKey("idusuario");

                    b.HasIndex("rolidrol");

                    b.HasIndex("tipodocumentoidtipodocumento");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Asignacion.Entidades.Asignatura", b =>
                {
                    b.HasOne("Asignacion.Entidades.Modalidad", "modalidad")
                        .WithMany("asignatura")
                        .HasForeignKey("idmodalidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Asignacion.Entidades.GrupoAula", b =>
                {
                    b.HasOne("Asignacion.Entidades.Aula", "aula")
                        .WithMany("grupoaulas")
                        .HasForeignKey("idaula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asignacion.Entidades.Grupo", "grupo")
                        .WithMany("grupoaulas")
                        .HasForeignKey("idgrupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Asignacion.Entidades.Horario", b =>
                {
                    b.HasOne("Asignacion.Entidades.Grupo", null)
                        .WithMany("horario")
                        .HasForeignKey("Grupoidgrupo");

                    b.HasOne("Asignacion.Entidades.DiaSemana", "diasemana")
                        .WithMany()
                        .HasForeignKey("diasemanaiddiasemana");
                });

            modelBuilder.Entity("Asignacion.Entidades.Programa", b =>
                {
                    b.HasOne("Asignacion.Entidades.Usuario", null)
                        .WithMany("programa")
                        .HasForeignKey("Usuarioidusuario");

                    b.HasOne("Asignacion.Entidades.Facultad", "facultad")
                        .WithMany("programa")
                        .HasForeignKey("idfacultad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asignacion.Entidades.Jornada", "jornada")
                        .WithMany("programa")
                        .HasForeignKey("idjornada")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Asignacion.Entidades.ProgramaAsignatura", b =>
                {
                    b.HasOne("Asignacion.Entidades.Asignatura", "asignatura")
                        .WithMany("programaasignaturas")
                        .HasForeignKey("idasignatura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asignacion.Entidades.Programa", "programa")
                        .WithMany("programaasignaturas")
                        .HasForeignKey("idprograma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Asignacion.Entidades.Sede", b =>
                {
                    b.HasOne("Asignacion.Entidades.Aula", null)
                        .WithMany("sede")
                        .HasForeignKey("Aulaidaula");
                });

            modelBuilder.Entity("Asignacion.Entidades.Usuario", b =>
                {
                    b.HasOne("Asignacion.Entidades.Rol", "rol")
                        .WithMany()
                        .HasForeignKey("rolidrol");

                    b.HasOne("Asignacion.Entidades.TipoDocumento", "tipodocumento")
                        .WithMany()
                        .HasForeignKey("tipodocumentoidtipodocumento");
                });
#pragma warning restore 612, 618
        }
    }
}