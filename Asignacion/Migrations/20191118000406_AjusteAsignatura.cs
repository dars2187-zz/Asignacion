using Microsoft.EntityFrameworkCore.Migrations;

namespace Asignacion.Migrations
{
    public partial class AjusteAsignatura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modalidad_Asignatura_Asignaturaidasignatura",
                table: "Modalidad");

            migrationBuilder.DropColumn(
                name: "idmodalidad",
                table: "Asignatura");

            migrationBuilder.RenameColumn(
                name: "Asignaturaidasignatura",
                table: "Modalidad",
                newName: "asignaturaidasignatura");

            migrationBuilder.RenameIndex(
                name: "IX_Modalidad_Asignaturaidasignatura",
                table: "Modalidad",
                newName: "IX_Modalidad_asignaturaidasignatura");

            migrationBuilder.AddForeignKey(
                name: "FK_Modalidad_Asignatura_asignaturaidasignatura",
                table: "Modalidad",
                column: "asignaturaidasignatura",
                principalTable: "Asignatura",
                principalColumn: "idasignatura",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modalidad_Asignatura_asignaturaidasignatura",
                table: "Modalidad");

            migrationBuilder.RenameColumn(
                name: "asignaturaidasignatura",
                table: "Modalidad",
                newName: "Asignaturaidasignatura");

            migrationBuilder.RenameIndex(
                name: "IX_Modalidad_asignaturaidasignatura",
                table: "Modalidad",
                newName: "IX_Modalidad_Asignaturaidasignatura");

            migrationBuilder.AddColumn<int>(
                name: "idmodalidad",
                table: "Asignatura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Modalidad_Asignatura_Asignaturaidasignatura",
                table: "Modalidad",
                column: "Asignaturaidasignatura",
                principalTable: "Asignatura",
                principalColumn: "idasignatura",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
