using Microsoft.EntityFrameworkCore.Migrations;

namespace Asignacion.Migrations
{
    public partial class Correccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modalidad_Asignatura_idasignatura",
                table: "Modalidad");

            migrationBuilder.DropIndex(
                name: "IX_Modalidad_idasignatura",
                table: "Modalidad");

            migrationBuilder.DropColumn(
                name: "idasignatura",
                table: "Modalidad");

            migrationBuilder.AddColumn<int>(
                name: "idmodalidad",
                table: "Asignatura",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_idmodalidad",
                table: "Asignatura",
                column: "idmodalidad");

            migrationBuilder.AddForeignKey(
                name: "FK_Asignatura_Modalidad_idmodalidad",
                table: "Asignatura",
                column: "idmodalidad",
                principalTable: "Modalidad",
                principalColumn: "idmodalidad",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asignatura_Modalidad_idmodalidad",
                table: "Asignatura");

            migrationBuilder.DropIndex(
                name: "IX_Asignatura_idmodalidad",
                table: "Asignatura");

            migrationBuilder.DropColumn(
                name: "idmodalidad",
                table: "Asignatura");

            migrationBuilder.AddColumn<int>(
                name: "idasignatura",
                table: "Modalidad",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Modalidad_idasignatura",
                table: "Modalidad",
                column: "idasignatura");

            migrationBuilder.AddForeignKey(
                name: "FK_Modalidad_Asignatura_idasignatura",
                table: "Modalidad",
                column: "idasignatura",
                principalTable: "Asignatura",
                principalColumn: "idasignatura",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
