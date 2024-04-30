using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JogoCards.Migrations
{
    /// <inheritdoc />
    public partial class PlayerAtualizacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personagens_Players_PlayerId",
                table: "Personagens");

            migrationBuilder.DropIndex(
                name: "IX_Personagens_PlayerId",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Personagens");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonagemPlayer");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Personagens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_PlayerId",
                table: "Personagens",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personagens_Players_PlayerId",
                table: "Personagens",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId");
        }
    }
}
