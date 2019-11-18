using Microsoft.EntityFrameworkCore.Migrations;

namespace Asignacion.Migrations
{
    public partial class AjusteModalidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Modalidad_idasignatura",
                table: "Modalidad");

            migrationBuilder.CreateIndex(
                name: "IX_Modalidad_idasignatura",
                table: "Modalidad",
                column: "idasignatura");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Modalidad_idasignatura",
                table: "Modalidad");

            migrationBuilder.CreateIndex(
                name: "IX_Modalidad_idasignatura",
                table: "Modalidad",
                column: "idasignatura",
                unique: true);
        }
    }
}
