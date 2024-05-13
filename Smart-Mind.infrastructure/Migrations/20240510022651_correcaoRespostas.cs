using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_Mind.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class correcaoRespostas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RespostasUsuarios_AlternativaId",
                table: "RespostasUsuarios",
                column: "AlternativaId");

            migrationBuilder.CreateIndex(
                name: "IX_RespostasUsuarios_UsuarioId",
                table: "RespostasUsuarios",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_RespostasUsuarios_Alternativas_AlternativaId",
                table: "RespostasUsuarios",
                column: "AlternativaId",
                principalTable: "Alternativas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RespostasUsuarios_Usuarios_UsuarioId",
                table: "RespostasUsuarios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespostasUsuarios_Alternativas_AlternativaId",
                table: "RespostasUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_RespostasUsuarios_Usuarios_UsuarioId",
                table: "RespostasUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_RespostasUsuarios_AlternativaId",
                table: "RespostasUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_RespostasUsuarios_UsuarioId",
                table: "RespostasUsuarios");
        }
    }
}
