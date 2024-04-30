public class Personagem
{
    public int PersonagemId { get; set;}
    public string? PersonagemName  { get; set;}
    public string? Class { get; set;}
    public string? Element { get; set;}
    public int HitPoints { get; set;}
    public string? Weakness { get; set;}
    public List<Card>? Cards { get; set;}
    public List<Player>? Players{ get; set;}


    
    public override string ToString()
    {
        return $"Id: {PersonagemId}, Nome: {PersonagemName}, Classe: {Class}, Elemento: {Element}, Vida: {HitPoints}, Fraqueza: {Weakness}, Cards: {Cards}";
    }
    
}