using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JogoCards.Migrations
{
    /// <inheritdoc />
    public partial class OnModelCreating : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "PersonagemId1",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PersonagemId1",
                table: "Cards",
                column: "PersonagemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Personagens_PersonagemId",
                table: "Cards",
                column: "PersonagemId",
                principalTable: "Personagens",
                principalColumn: "PersonagemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Personagens_PersonagemId1",
                table: "Cards",
                column: "PersonagemId1",
                principalTable: "Personagens",
                principalColumn: "PersonagemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Personagens_PersonagemId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Personagens_PersonagemId1",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_PersonagemId1",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "PersonagemId1",
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
