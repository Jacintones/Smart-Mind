using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_Mind.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tabelaExplicacoesAssuntos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssuntoId",
                table: "Explicacao",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExplicacaoAssuntos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Texto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Imagem = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AssuntoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExplicacaoAssuntos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExplicacaoAssuntos_Assuntos_AssuntoId",
                        column: x => x.AssuntoId,
                        principalTable: "Assuntos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Explicacao_AssuntoId",
                table: "Explicacao",
                column: "AssuntoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExplicacaoAssuntos_AssuntoId",
                table: "ExplicacaoAssuntos",
                column: "AssuntoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Explicacao_Assuntos_AssuntoId",
                table: "Explicacao",
                column: "AssuntoId",
                principalTable: "Assuntos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Explicacao_Assuntos_AssuntoId",
                table: "Explicacao");

            migrationBuilder.DropTable(
                name: "ExplicacaoAssuntos");

            migrationBuilder.DropIndex(
                name: "IX_Explicacao_AssuntoId",
                table: "Explicacao");

            migrationBuilder.DropColumn(
                name: "AssuntoId",
                table: "Explicacao");
        }
    }
}
