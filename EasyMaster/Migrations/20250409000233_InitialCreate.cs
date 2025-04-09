using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyMaster.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sistemas",
                columns: table => new
                {
                    IdSistema = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sistemas", x => x.IdSistema);
                });

            migrationBuilder.CreateTable(
                name: "Personagens",
                columns: table => new
                {
                    IdPersonagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSistema = table.Column<int>(type: "int", nullable: false),
                    SistemaIdSistema = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagens", x => x.IdPersonagem);
                    table.ForeignKey(
                        name: "FK_Personagens_Sistemas_SistemaIdSistema",
                        column: x => x.SistemaIdSistema,
                        principalTable: "Sistemas",
                        principalColumn: "IdSistema",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modulos",
                columns: table => new
                {
                    IdModulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    IdSistema = table.Column<int>(type: "int", nullable: false),
                    SistemaIdSistema = table.Column<int>(type: "int", nullable: false),
                    PersonagemIdPersonagem = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulos", x => x.IdModulo);
                    table.ForeignKey(
                        name: "FK_Modulos_Personagens_PersonagemIdPersonagem",
                        column: x => x.PersonagemIdPersonagem,
                        principalTable: "Personagens",
                        principalColumn: "IdPersonagem");
                    table.ForeignKey(
                        name: "FK_Modulos_Sistemas_SistemaIdSistema",
                        column: x => x.SistemaIdSistema,
                        principalTable: "Sistemas",
                        principalColumn: "IdSistema",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Componentes",
                columns: table => new
                {
                    IdComponente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdModulo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModuloIdModulo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componentes", x => x.IdComponente);
                    table.ForeignKey(
                        name: "FK_Componentes_Modulos_ModuloIdModulo",
                        column: x => x.ModuloIdModulo,
                        principalTable: "Modulos",
                        principalColumn: "IdModulo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Componentes_ModuloIdModulo",
                table: "Componentes",
                column: "ModuloIdModulo");

            migrationBuilder.CreateIndex(
                name: "IX_Modulos_PersonagemIdPersonagem",
                table: "Modulos",
                column: "PersonagemIdPersonagem");

            migrationBuilder.CreateIndex(
                name: "IX_Modulos_SistemaIdSistema",
                table: "Modulos",
                column: "SistemaIdSistema");

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_SistemaIdSistema",
                table: "Personagens",
                column: "SistemaIdSistema");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Componentes");

            migrationBuilder.DropTable(
                name: "Modulos");

            migrationBuilder.DropTable(
                name: "Personagens");

            migrationBuilder.DropTable(
                name: "Sistemas");
        }
    }
}
