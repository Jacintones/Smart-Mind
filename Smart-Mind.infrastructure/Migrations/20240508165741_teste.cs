using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_Mind.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestaoTeste");

            migrationBuilder.CreateTable(
                name: "TesteQuestoes",
                columns: table => new
                {
                    QuestoesId = table.Column<int>(type: "int", nullable: false),
                    TestesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TesteQuestoes", x => new { x.TestesId, x.QuestoesId });
                    table.ForeignKey(
                        name: "FK_TesteQuestoes_Questoes_QuestoesId",
                        column: x => x.QuestoesId,
                        principalTable: "Questoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TesteQuestoes_Testes_TestesId",
                        column: x => x.TestesId,
                        principalTable: "Testes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TesteQuestoes_QuestoesId",
                table: "TesteQuestoes",
                column: "QuestoesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TesteQuestoes");

            migrationBuilder.CreateTable(
                name: "QuestaoTeste",
                columns: table => new
                {
                    QuestoesId = table.Column<int>(type: "int", nullable: false),
                    TestesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestaoTeste", x => new { x.QuestoesId, x.TestesId });
                    table.ForeignKey(
                        name: "FK_QuestaoTeste_Questoes_QuestoesId",
                        column: x => x.QuestoesId,
                        principalTable: "Questoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestaoTeste_Testes_TestesId",
                        column: x => x.TestesId,
                        principalTable: "Testes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_QuestaoTeste_TestesId",
                table: "QuestaoTeste",
                column: "TestesId");
        }
    }
}
