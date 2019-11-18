using Microsoft.EntityFrameworkCore.Migrations;

namespace Asignacion.Migrations
{
    public partial class Ajustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aula_Grupo_Grupoidgrupo",
                table: "Aula");

            migrationBuilder.DropIndex(
                name: "IX_Aula_Grupoidgrupo",
                table: "Aula");

            migrationBuilder.DropColumn(
                name: "Grupoidgrupo",
                table: "Aula");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Grupoidgrupo",
                table: "Aula",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aula_Grupoidgrupo",
                table: "Aula",
                column: "Grupoidgrupo");

            migrationBuilder.AddForeignKey(
                name: "FK_Aula_Grupo_Grupoidgrupo",
                table: "Aula",
                column: "Grupoidgrupo",
                principalTable: "Grupo",
                principalColumn: "idgrupo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
