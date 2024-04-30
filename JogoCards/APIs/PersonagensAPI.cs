using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

public static class PersonagensAPI
{
    public static void MapPersonagensAPI(this WebApplication app){
        
        app.MapGet("/personagens", async (BancoDeDados db) =>{
            // select * from Cards
            
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };
            var personagens = await db.Personagens.Include(p => p.Cards).ToListAsync();
            return JsonSerializer.Serialize(personagens, options);
            
            
        });


        app.MapGet("/personagens/{id}", async (int id, BancoDeDados db) =>{
            
            var personagem = await db.Personagens.FindAsync(id);
            return personagem;
        });

        app.MapPost("/personagens", async (Personagem personagem, BancoDeDados db) =>{
            // Tratamento para salvar card incluindo personagem.
            Console.WriteLine($"Personagem: {personagem}");

            // Tratamento para salvar endereços com e sem Ids.
            personagem.Cards = await TratarCards(personagem, db);
            
            db.Personagens.Add(personagem);
            //insert into...
            await db.SaveChangesAsync();

            return Results.Created($"/personagens/{personagem.PersonagemId}", personagem);

        });


        app.MapPut("/personagens/{id}", async (int id, Personagem personagemAlterado, BancoDeDados db) =>{
            
            var personagem = await db.Personagens.FindAsync(id);
            if (personagem is null)
            {
                return Results.NotFound();
            }
            personagem.PersonagemName = personagemAlterado.PersonagemName;
            personagem.Class = personagemAlterado.Class;
            personagem.Element = personagemAlterado.Element;
            personagem.HitPoints = personagemAlterado.HitPoints;
            personagem.Weakness = personagemAlterado.Weakness;
            

            personagem.Cards = await TratarCards(personagem, db);

            //update....
            await db.SaveChangesAsync();

            return Results.NoContent();
        });


        app.MapDelete("/personagens/{id}", async (int id, BancoDeDados db) =>{
            if (await db.Personagens.FindAsync(id) is Personagem personagem)
            {
            //Operações de exclusão
            db.Personagens.Remove(personagem);
            //delete from...
            await db.SaveChangesAsync();
            return Results.NoContent();
            }
            return Results.NotFound();

        });
    }

    

    static async Task<List<Card>> TratarCards(Personagem personagem, BancoDeDados db)
    {
      List<Card> cards = new();
      if (personagem is not null && personagem.Cards is not null 
          && personagem.Cards.Count > 0){

        foreach (var card in personagem.Cards)
        {
          Console.WriteLine($"Card: {card}");
          if (card.CardId > 0)
          {
            var eExistente = await db.Cards.FindAsync(card.CardId);
            if (eExistente is not null)
            {
              cards.Add(eExistente);
            }
          }
          else
          {
            cards.Add(card);
          }
        }
      }
      return cards;
    }

}