using Microsoft.EntityFrameworkCore.Migrations;

namespace Asignacion.Migrations
{
    public partial class AjustesPrograma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facultad_Programa_Programaidprograma",
                table: "Facultad");

            migrationBuilder.DropForeignKey(
                name: "FK_Jornada_Programa_Programaidprograma",
                table: "Jornada");

            migrationBuilder.DropIndex(
                name: "IX_Jornada_Programaidprograma",
                table: "Jornada");

            migrationBuilder.DropIndex(
                name: "IX_Facultad_Programaidprograma",
                table: "Facultad");

            migrationBuilder.DropColumn(
                name: "Programaidprograma",
                table: "Jornada");

            migrationBuilder.DropColumn(
                name: "Programaidprograma",
                table: "Facultad");

            migrationBuilder.CreateIndex(
                name: "IX_Programa_idfacultad",
                table: "Programa",
                column: "idfacultad");

            migrationBuilder.CreateIndex(
                name: "IX_Programa_idjornada",
                table: "Programa",
                column: "idjornada");

            migrationBuilder.AddForeignKey(
                name: "FK_Programa_Facultad_idfacultad",
                table: "Programa",
                column: "idfacultad",
                principalTable: "Facultad",
                principalColumn: "idfacultad",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Programa_Jornada_idjornada",
                table: "Programa",
                column: "idjornada",
                principalTable: "Jornada",
                principalColumn: "idjornada",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programa_Facultad_idfacultad",
                table: "Programa");

            migrationBuilder.DropForeignKey(
                name: "FK_Programa_Jornada_idjornada",
                table: "Programa");

            migrationBuilder.DropIndex(
                name: "IX_Programa_idfacultad",
                table: "Programa");

            migrationBuilder.DropIndex(
                name: "IX_Programa_idjornada",
                table: "Programa");

            migrationBuilder.AddColumn<int>(
                name: "Programaidprograma",
                table: "Jornada",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Programaidprograma",
                table: "Facultad",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jornada_Programaidprograma",
                table: "Jornada",
                column: "Programaidprograma");

            migrationBuilder.CreateIndex(
                name: "IX_Facultad_Programaidprograma",
                table: "Facultad",
                column: "Programaidprograma");

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
        }
    }
}
