public class Deck
{
    public int DeckId { get; set; }
    public string DeckName { get; set; }
    public Player Owner { get; set; }
    public List<Card> Cards { get; set; }

    public Deck(int DeckId, string DeckName, Player Owner, List<Card> Cards)
    {
        this.DeckId = DeckId;
        this.DeckName = DeckName;
        this.Owner = Owner;
        this.Cards = Cards;
    }
}