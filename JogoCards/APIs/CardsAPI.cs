using System.Text.Json;
using Microsoft.EntityFrameworkCore;

public static class CardsAPI
{
    public static void MapCardsAPI(this WebApplication app){
        
        app.MapGet("/cards", async (BancoDeDados db) =>{
            // select * from Cards
            var cards = await db.Cards.ToListAsync();
            return cards;
        });


        app.MapGet("/cards/{id}", async (int id, BancoDeDados db) => {
            var card = await db.Cards.FindAsync(id);
            return card;
        });

        app.MapPost("/cards", async (Card card, BancoDeDados db) =>{
            // Tratamento para salvar card incluindo personagem.
            if (card.PersonagemId != 0)
            {
            var personagem = await db.Personagens.FindAsync(card.PersonagemId);
            if (personagem is not null)
            {
                card.Personagem = personagem;
            }
            }
            else
            {
            return Results.BadRequest("Personagem com Id é obrigatório");
            }

            db.Cards.Add(card);
            //insert into...
            await db.SaveChangesAsync();

            return Results.Created($"/cards/{card.CardId}", card);
        });


        app.MapPut("/cards/{id}", async (int id, Card cardAlterado, BancoDeDados db) =>{
            //select * from Cards where id = ?
            var card = await db.Cards.FindAsync(id);
            if (card is null)
            {
                return Results.NotFound();
            }
            card.CardName = cardAlterado.CardName;
            card.TypeCard = cardAlterado.TypeCard;
            card.Element = cardAlterado.Element;
            card.Damage = cardAlterado.Damage;
            card.ManaCost = cardAlterado.ManaCost;
            card.TaxaDrop = cardAlterado.TaxaDrop;

            // Tratamento para salvar cards incluindo personagem.
            if (card.PersonagemId != 0)
            {
            var personagem = await db.Personagens.FindAsync(card.PersonagemId);
            if (personagem is not null)
            {
                card.Personagem = personagem;
            }
            }
            else
            {
            return Results.BadRequest("Personagem com Id é obrigatório");
            }

            //update....
            await db.SaveChangesAsync();

            return Results.NoContent();
        });


        app.MapDelete("/cards/{id}", async (int id, BancoDeDados db) =>{
            if (await db.Cards.FindAsync(id) is Card card)
            {
            //Operações de exclusão
            db.Cards.Remove(card);
            //delete from...
            await db.SaveChangesAsync();
            return Results.NoContent();
            }
            return Results.NotFound();
        });
    }
}