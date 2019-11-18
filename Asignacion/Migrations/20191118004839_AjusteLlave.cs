using Microsoft.EntityFrameworkCore.Migrations;

namespace Asignacion.Migrations
{
    public partial class AjusteLlave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modalidad_Asignatura_asignaturaidasignatura",
                table: "Modalidad");

            migrationBuilder.DropIndex(
                name: "IX_Modalidad_asignaturaidasignatura",
                table: "Modalidad");

            migrationBuilder.DropColumn(
                name: "asignaturaidasignatura",
                table: "Modalidad");

            migrationBuilder.AddColumn<int>(
                name: "idasignatura",
                table: "Modalidad",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Modalidad_idasignatura",
                table: "Modalidad",
                column: "idasignatura",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Modalidad_Asignatura_idasignatura",
                table: "Modalidad",
                column: "idasignatura",
                principalTable: "Asignatura",
                principalColumn: "idasignatura",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "asignaturaidasignatura",
                table: "Modalidad",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modalidad_asignaturaidasignatura",
                table: "Modalidad",
                column: "asignaturaidasignatura");

            migrationBuilder.AddForeignKey(
                name: "FK_Modalidad_Asignatura_asignaturaidasignatura",
                table: "Modalidad",
                column: "asignaturaidasignatura",
                principalTable: "Asignatura",
                principalColumn: "idasignatura",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
