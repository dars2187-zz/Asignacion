using Microsoft.EntityFrameworkCore.Migrations;

namespace Asignacion.Migrations
{
    public partial class Aula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aula",
                columns: table => new
                {
                    idaula = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numaula = table.Column<string>(maxLength: 10, nullable: false),
                    idsede = table.Column<int>(nullable: false),
                    sedeidsede = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aula", x => x.idaula);
                    table.ForeignKey(
                        name: "FK_Aula_Sede_sedeidsede",
                        column: x => x.sedeidsede,
                        principalTable: "Sede",
                        principalColumn: "idsede",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aula_sedeidsede",
                table: "Aula",
                column: "sedeidsede");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aula");
        }
    }
}
