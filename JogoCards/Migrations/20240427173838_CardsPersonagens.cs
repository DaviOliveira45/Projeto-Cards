using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace JogoCards.Migrations
{
    /// <inheritdoc />
    public partial class CardsPersonagens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personagens",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PersonagemName = table.Column<string>(type: "longtext", nullable: true),
                    Class = table.Column<string>(type: "longtext", nullable: true),
                    Element = table.Column<string>(type: "longtext", nullable: true),
                    HitPoints = table.Column<int>(type: "int", nullable: false),
                    Weakness = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagens", x => x.PersonagemId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CardName = table.Column<string>(type: "longtext", nullable: true),
                    TypeCard = table.Column<string>(type: "longtext", nullable: true),
                    Element = table.Column<string>(type: "longtext", nullable: true),
                    Damage = table.Column<double>(type: "double", nullable: false),
                    ManaCost = table.Column<int>(type: "int", nullable: false),
                    TaxaDrop = table.Column<double>(type: "double", nullable: false),
                    PersonagemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_Cards_Personagens_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagens",
                        principalColumn: "PersonagemId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PersonagemId",
                table: "Cards",
                column: "PersonagemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Personagens");
        }
    }
}
