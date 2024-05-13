using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_Mind.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BooleanoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Acertou",
                table: "RespostasUsuarios",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acertou",
                table: "RespostasUsuarios");
        }
    }
}
