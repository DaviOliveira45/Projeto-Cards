using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JogoCards.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Personagens_PersonagemId",
                table: "Cards");

            migrationBuilder.AlterColumn<int>(
                name: "PersonagemId",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Personagens_PersonagemId",
                table: "Cards",
                column: "PersonagemId",
                principalTable: "Personagens",
                principalColumn: "PersonagemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Personagens_PersonagemId",
                table: "Cards");

            migrationBuilder.AlterColumn<int>(
                name: "PersonagemId",
                table: "Cards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Personagens_PersonagemId",
                table: "Cards",
                column: "PersonagemId",
                principalTable: "Personagens",
                principalColumn: "PersonagemId");
        }
    }
}
