using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

public class Card
{
    public int CardId { get; set;}
    public string? CardName  { get; set;}
    public string? TypeCard { get; set;}
    public string? Element { get; set;}
    public double Damage { get; set;}
    public int ManaCost { get; set;}
    public double TaxaDrop { get; set;}
    public int PersonagemId { get; set;}
    public Personagem? Personagem { get; set;}


    public override string ToString()
    {
        return $"Id: {CardId}, Nome: {CardName}, Tipo: {TypeCard}, Elemento: {Element}, Dano: {Damage}, Custo de Mana: {ManaCost}, Taxa de Dropar: {TaxaDrop}, Personagem: {PersonagemId}";
    }

}