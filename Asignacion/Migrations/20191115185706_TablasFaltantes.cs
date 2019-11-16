using Microsoft.EntityFrameworkCore.Migrations;

namespace Asignacion.Migrations
{
    public partial class TablasFaltantes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aula_Sede_sedeidsede",
                table: "Aula");

            migrationBuilder.DropIndex(
                name: "IX_Aula_sedeidsede",
                table: "Aula");

            migrationBuilder.DropColumn(
                name: "sedeidsede",
                table: "Aula");

            migrationBuilder.AddColumn<int>(
                name: "Aulaidaula",
                table: "Sede",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Asignaturaidasignatura",
                table: "Modalidad",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Programaidprograma",
                table: "Jornada",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Programaidprograma",
                table: "Facultad",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Grupoidgrupo",
                table: "Aula",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Asignatura",
                columns: table => new
                {
                    idasignatura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(maxLength: 50, nullable: false),
                    credito = table.Column<int>(nullable: false),
                    idmodalidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignatura", x => x.idasignatura);
                });

            migrationBuilder.CreateTable(
                name: "Grupo",
                columns: table => new
                {
                    idgrupo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(maxLength: 50, nullable: false),
                    idhorario = table.Column<int>(nullable: false),
                    idasignatura = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo", x => x.idgrupo);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idusuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numdocumento = table.Column<string>(maxLength: 50, nullable: false),
                    nombre = table.Column<string>(maxLength: 100, nullable: false),
                    apellido = table.Column<string>(maxLength: 100, nullable: false),
                    correo = table.Column<string>(nullable: false),
                    telefono = table.Column<int>(nullable: false),
                    clave = table.Column<string>(maxLength: 50, nullable: true),
                    estado = table.Column<bool>(nullable: false),
                    idrol = table.Column<int>(nullable: false),
                    idtipodocumento = table.Column<int>(nullable: false),
                    rolidrol = table.Column<int>(nullable: true),
                    tipodocumentoidtipodocumento = table.Column<int>(nullable: true),
                    idprograma = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idusuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_rolidrol",
                        column: x => x.rolidrol,
                        principalTable: "Rol",
                        principalColumn: "idrol",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoDocumento_tipodocumentoidtipodocumento",
                        column: x => x.tipodocumentoidtipodocumento,
                        principalTable: "TipoDocumento",
                        principalColumn: "idtipodocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GrupoAula",
                columns: table => new
                {
                    idgrupo = table.Column<int>(nullable: false),
                    idaula = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoAula", x => new { x.idgrupo, x.idaula });
                    table.ForeignKey(
                        name: "FK_GrupoAula_Aula_idaula",
                        column: x => x.idaula,
                        principalTable: "Aula",
                        principalColumn: "idaula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrupoAula_Grupo_idgrupo",
                        column: x => x.idgrupo,
                        principalTable: "Grupo",
                        principalColumn: "idgrupo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    idhorario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    horainicio = table.Column<string>(maxLength: 5, nullable: true),
                    horafin = table.Column<string>(maxLength: 5, nullable: true),
                    iddiasemana = table.Column<int>(nullable: false),
                    diasemanaiddiasemana = table.Column<int>(nullable: true),
                    Grupoidgrupo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.idhorario);
                    table.ForeignKey(
                        name: "FK_Horario_Grupo_Grupoidgrupo",
                        column: x => x.Grupoidgrupo,
                        principalTable: "Grupo",
                        principalColumn: "idgrupo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Horario_DiaSemana_diasemanaiddiasemana",
                        column: x => x.diasemanaiddiasemana,
                        principalTable: "DiaSemana",
                        principalColumn: "iddiasemana",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Programa",
                columns: table => new
                {
                    idprograma = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(maxLength: 50, nullable: false),
                    idfacultad = table.Column<int>(nullable: false),
                    idjornada = table.Column<int>(nullable: false),
                    Usuarioidusuario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programa", x => x.idprograma);
                    table.ForeignKey(
                        name: "FK_Programa_Usuario_Usuarioidusuario",
                        column: x => x.Usuarioidusuario,
                        principalTable: "Usuario",
                        principalColumn: "idusuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProgramaAsignatura",
                columns: table => new
                {
                    idasignatura = table.Column<int>(nullable: false),
                    idprograma = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramaAsignatura", x => new { x.idprograma, x.idasignatura });
                    table.ForeignKey(
                        name: "FK_ProgramaAsignatura_Asignatura_idasignatura",
                        column: x => x.idasignatura,
                        principalTable: "Asignatura",
                        principalColumn: "idasignatura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramaAsignatura_Programa_idprograma",
                        column: x => x.idprograma,
                        principalTable: "Programa",
                        principalColumn: "idprograma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sede_Aulaidaula",
                table: "Sede",
                column: "Aulaidaula");

            migrationBuilder.CreateIndex(
                name: "IX_Modalidad_Asignaturaidasignatura",
                table: "Modalidad",
                column: "Asignaturaidasignatura");

            migrationBuilder.CreateIndex(
                name: "IX_Jornada_Programaidprograma",
                table: "Jornada",
                column: "Programaidprograma");

            migrationBuilder.CreateIndex(
                name: "IX_Facultad_Programaidprograma",
                table: "Facultad",
                column: "Programaidprograma");

            migrationBuilder.CreateIndex(
                name: "IX_Aula_Grupoidgrupo",
                table: "Aula",
                column: "Grupoidgrupo");

            migrationBuilder.CreateIndex(
                name: "IX_Grupo_descripcion",
                table: "Grupo",
                column: "descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GrupoAula_idaula",
                table: "GrupoAula",
                column: "idaula");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_Grupoidgrupo",
                table: "Horario",
                column: "Grupoidgrupo");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_diasemanaiddiasemana",
                table: "Horario",
                column: "diasemanaiddiasemana");

            migrationBuilder.CreateIndex(
                name: "IX_Programa_Usuarioidusuario",
                table: "Programa",
                column: "Usuarioidusuario");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaAsignatura_idasignatura",
                table: "ProgramaAsignatura",
                column: "idasignatura");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_rolidrol",
                table: "Usuario",
                column: "rolidrol");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_tipodocumentoidtipodocumento",
                table: "Usuario",
                column: "tipodocumentoidtipodocumento");

            migrationBuilder.AddForeignKey(
                name: "FK_Aula_Grupo_Grupoidgrupo",
                table: "Aula",
                column: "Grupoidgrupo",
                principalTable: "Grupo",
                principalColumn: "idgrupo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facultad_Programa_Programaidprograma",
                table: "Facultad",
                column: "Programaidprograma",
                principalTable: "Programa",
                principalColumn: "idprograma",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jornada_Programa_Programaidprograma",
                table: "Jornada",
                column: "Programaidprograma",
                principalTable: "Programa",
                principalColumn: "idprograma",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Modalidad_Asignatura_Asignaturaidasignatura",
                table: "Modalidad",
                column: "Asignaturaidasignatura",
                principalTable: "Asignatura",
                principalColumn: "idasignatura",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sede_Aula_Aulaidaula",
                table: "Sede",
                column: "Aulaidaula",
                principalTable: "Aula",
                principalColumn: "idaula",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aula_Grupo_Grupoidgrupo",
                table: "Aula");

            migrationBuilder.DropForeignKey(
                name: "FK_Facultad_Programa_Programaidprograma",
                table: "Facultad");

            migrationBuilder.DropForeignKey(
                name: "FK_Jornada_Programa_Programaidprograma",
                table: "Jornada");

            migrationBuilder.DropForeignKey(
                name: "FK_Modalidad_Asignatura_Asignaturaidasignatura",
                table: "Modalidad");

            migrationBuilder.DropForeignKey(
                name: "FK_Sede_Aula_Aulaidaula",
                table: "Sede");

            migrationBuilder.DropTable(
                name: "GrupoAula");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "ProgramaAsignatura");

            migrationBuilder.DropTable(
                name: "Grupo");

            migrationBuilder.DropTable(
                name: "Asignatura");

            migrationBuilder.DropTable(
                name: "Programa");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Sede_Aulaidaula",
                table: "Sede");

            migrationBuilder.DropIndex(
                name: "IX_Modalidad_Asignaturaidasignatura",
                table: "Modalidad");

            migrationBuilder.DropIndex(
                name: "IX_Jornada_Programaidprograma",
                table: "Jornada");

            migrationBuilder.DropIndex(
                name: "IX_Facultad_Programaidprograma",
                table: "Facultad");

            migrationBuilder.DropIndex(
                name: "IX_Aula_Grupoidgrupo",
                table: "Aula");

            migrationBuilder.DropColumn(
                name: "Aulaidaula",
                table: "Sede");

            migrationBuilder.DropColumn(
                name: "Asignaturaidasignatura",
                table: "Modalidad");

            migrationBuilder.DropColumn(
                name: "Programaidprograma",
                table: "Jornada");

            migrationBuilder.DropColumn(
                name: "Programaidprograma",
                table: "Facultad");

            migrationBuilder.DropColumn(
                name: "Grupoidgrupo",
                table: "Aula");

            migrationBuilder.AddColumn<int>(
                name: "sedeidsede",
                table: "Aula",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aula_sedeidsede",
                table: "Aula",
                column: "sedeidsede");

            migrationBuilder.AddForeignKey(
                name: "FK_Aula_Sede_sedeidsede",
                table: "Aula",
                column: "sedeidsede",
                principalTable: "Sede",
                principalColumn: "idsede",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
