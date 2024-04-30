using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

public static class PlayersAPI
{
    public static void MapPlayersAPI(this WebApplication app){
        
        app.MapGet("/players", async (BancoDeDados db) =>{
            
            var players = await db.Players.ToListAsync();
            return players;
        });


        app.MapGet("/players/{id}", async (int id, BancoDeDados db) => {
            var player = await db.Players.FindAsync(id);
            return player;
        });

        app.MapPost("/players", async (Player player, BancoDeDados db) =>{
            // Verifica se o jogador tem um nome
            if (string.IsNullOrWhiteSpace(player.PlayerName))
            {
                return Results.BadRequest("O nome do jogador é obrigatório");
            }

            // Adiciona o jogador ao contexto
            db.Players.Add(player);

            await db.SaveChangesAsync();
            
            return Results.Created($"/players/{player.PlayerId}", player);
        });




        app.MapPut("/players/{id}", async (int id, Player playerAlterado, BancoDeDados db) => {
            // Busca o jogador pelo ID
            var player = await db.Players.FindAsync(id);
            
            // Verifica se o jogador foi encontrado
            if (player == null) {
                return Results.NotFound(); // Retorna 404 Not Found se o jogador não existe
            }

            // Atualiza os dados do jogador com os valores fornecidos
            player.PlayerName = playerAlterado.PlayerName;
            player.PlayerLevel = playerAlterado.PlayerLevel;
            player.Balance = playerAlterado.Balance;
            player.Coins = playerAlterado.Coins;
            player.Mana = playerAlterado.Mana;
            player.Xp = playerAlterado.Xp;
            player.PersonagemId = playerAlterado.PersonagemId;

            // Salva as alterações no banco de dados
            await db.SaveChangesAsync();

            return Results.NoContent();
        });


        app.MapDelete("/players/{id}", async (int id, BancoDeDados db) =>{
            if (await db.Players.FindAsync(id) is Player player)
            {
            //Operações de exclusão
            db.Players.Remove(player);
            //delete from...
            await db.SaveChangesAsync();
            return Results.NoContent();
            }
            return Results.NotFound();
        });
    }
}