using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace JogoCards.Migrations
{
    /// <inheritdoc />
    public partial class PlayerAdicionado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Personagens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PlayerName = table.Column<string>(type: "longtext", nullable: true),
                    PlayerLevel = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<double>(type: "double", nullable: false),
                    Coins = table.Column<int>(type: "int", nullable: false),
                    Mana = table.Column<int>(type: "int", nullable: false),
                    Xp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personagens_Players_PlayerId",
                table: "Personagens");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Personagens_PlayerId",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Personagens");
        }
    }
}
