using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JogoCards.Migrations
{
    /// <inheritdoc />
    public partial class Voltar3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonagemPlayer");

            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Players_PersonagemId",
                table: "Players",
                column: "PersonagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Personagens_PersonagemId",
                table: "Players",
                column: "PersonagemId",
                principalTable: "Personagens",
                principalColumn: "PersonagemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Personagens_PersonagemId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_PersonagemId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "Players");

            migrationBuilder.CreateTable(
                name: "PersonagemPlayer",
                columns: table => new
                {
                    PersonagensPersonagemId = table.Column<int>(type: "int", nullable: false),
                    PlayersPlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonagemPlayer", x => new { x.PersonagensPersonagemId, x.PlayersPlayerId });
                    table.ForeignKey(
                        name: "FK_PersonagemPlayer_Personagens_PersonagensPersonagemId",
                        column: x => x.PersonagensPersonagemId,
                        principalTable: "Personagens",
                        principalColumn: "PersonagemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonagemPlayer_Players_PlayersPlayerId",
                        column: x => x.PlayersPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PersonagemPlayer_PlayersPlayerId",
                table: "PersonagemPlayer",
                column: "PlayersPlayerId");
        }
    }
}
