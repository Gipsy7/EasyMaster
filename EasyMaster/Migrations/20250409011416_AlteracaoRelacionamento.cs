using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyMaster.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoRelacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Componentes_Modulos_ModuloIdModulo",
                table: "Componentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Modulos_Sistemas_SistemaIdSistema",
                table: "Modulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Personagens_Sistemas_SistemaIdSistema",
                table: "Personagens");

            migrationBuilder.DropIndex(
                name: "IX_Personagens_SistemaIdSistema",
                table: "Personagens");

            migrationBuilder.DropIndex(
                name: "IX_Modulos_SistemaIdSistema",
                table: "Modulos");

            migrationBuilder.DropIndex(
                name: "IX_Componentes_ModuloIdModulo",
                table: "Componentes");

            migrationBuilder.DropColumn(
                name: "SistemaIdSistema",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "SistemaIdSistema",
                table: "Modulos");

            migrationBuilder.DropColumn(
                name: "ModuloIdModulo",
                table: "Componentes");

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_IdSistema",
                table: "Personagens",
                column: "IdSistema");

            migrationBuilder.CreateIndex(
                name: "IX_Modulos_IdSistema",
                table: "Modulos",
                column: "IdSistema");

            migrationBuilder.CreateIndex(
                name: "IX_Componentes_IdModulo",
                table: "Componentes",
                column: "IdModulo");

            migrationBuilder.AddForeignKey(
                name: "FK_Componentes_Modulos_IdModulo",
                table: "Componentes",
                column: "IdModulo",
                principalTable: "Modulos",
                principalColumn: "IdModulo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modulos_Sistemas_IdSistema",
                table: "Modulos",
                column: "IdSistema",
                principalTable: "Sistemas",
                principalColumn: "IdSistema",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personagens_Sistemas_IdSistema",
                table: "Personagens",
                column: "IdSistema",
                principalTable: "Sistemas",
                principalColumn: "IdSistema",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Componentes_Modulos_IdModulo",
                table: "Componentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Modulos_Sistemas_IdSistema",
                table: "Modulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Personagens_Sistemas_IdSistema",
                table: "Personagens");

            migrationBuilder.DropIndex(
                name: "IX_Personagens_IdSistema",
                table: "Personagens");

            migrationBuilder.DropIndex(
                name: "IX_Modulos_IdSistema",
                table: "Modulos");

            migrationBuilder.DropIndex(
                name: "IX_Componentes_IdModulo",
                table: "Componentes");

            migrationBuilder.AddColumn<int>(
                name: "SistemaIdSistema",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SistemaIdSistema",
                table: "Modulos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModuloIdModulo",
                table: "Componentes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_SistemaIdSistema",
                table: "Personagens",
                column: "SistemaIdSistema");

            migrationBuilder.CreateIndex(
                name: "IX_Modulos_SistemaIdSistema",
                table: "Modulos",
                column: "SistemaIdSistema");

            migrationBuilder.CreateIndex(
                name: "IX_Componentes_ModuloIdModulo",
                table: "Componentes",
                column: "ModuloIdModulo");

            migrationBuilder.AddForeignKey(
                name: "FK_Componentes_Modulos_ModuloIdModulo",
                table: "Componentes",
                column: "ModuloIdModulo",
                principalTable: "Modulos",
                principalColumn: "IdModulo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modulos_Sistemas_SistemaIdSistema",
                table: "Modulos",
                column: "SistemaIdSistema",
                principalTable: "Sistemas",
                principalColumn: "IdSistema",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personagens_Sistemas_SistemaIdSistema",
                table: "Personagens",
                column: "SistemaIdSistema",
                principalTable: "Sistemas",
                principalColumn: "IdSistema",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
