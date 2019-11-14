using Microsoft.EntityFrameworkCore.Migrations;

namespace Asignacion.Migrations
{
    public partial class dbasignacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tipodocumento",
                table: "tipodocumento");

            migrationBuilder.RenameTable(
                name: "tipodocumento",
                newName: "TipoDocumento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoDocumento",
                table: "TipoDocumento",
                column: "idtipodocumento");

            migrationBuilder.CreateTable(
                name: "DiaSemana",
                columns: table => new
                {
                    iddiasemana = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaSemana", x => x.iddiasemana);
                });

            migrationBuilder.CreateTable(
                name: "Facultad",
                columns: table => new
                {
                    idfacultad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultad", x => x.idfacultad);
                });

            migrationBuilder.CreateTable(
                name: "Jornada",
                columns: table => new
                {
                    idjornada = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jornada", x => x.idjornada);
                });

            migrationBuilder.CreateTable(
                name: "Modalidad",
                columns: table => new
                {
                    idmodalidad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalidad", x => x.idmodalidad);
                });

            migrationBuilder.CreateTable(
                name: "Parametro",
                columns: table => new
                {
                    idparametro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(maxLength: 50, nullable: false),
                    valor = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametro", x => x.idparametro);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    idrol = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.idrol);
                });

            migrationBuilder.CreateTable(
                name: "Sede",
                columns: table => new
                {
                    idsede = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sede", x => x.idsede);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaSemana");

            migrationBuilder.DropTable(
                name: "Facultad");

            migrationBuilder.DropTable(
                name: "Jornada");

            migrationBuilder.DropTable(
                name: "Modalidad");

            migrationBuilder.DropTable(
                name: "Parametro");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Sede");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoDocumento",
                table: "TipoDocumento");

            migrationBuilder.RenameTable(
                name: "TipoDocumento",
                newName: "tipodocumento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tipodocumento",
                table: "tipodocumento",
                column: "idtipodocumento");
        }
    }
}
