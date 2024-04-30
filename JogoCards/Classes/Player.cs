using System.Collections;

public class Player
{
    public int PlayerId { get; set; }
    public string? PlayerName { get; set;}
    public int PlayerLevel { get; set; } = 0;
    public double Balance { get; set; } = 0;
    public int Coins { get; set; } = 0;
    public int Mana { get; set; } = 5;
    public int Xp { get; set; } = 0;
    public int PersonagemId { get; set; }
    public Personagem? Personagem { get; set; }



    /*
    // Funções relacionadas ao player

    public void WinCoins(int CoinsWin){
        this.Coins += CoinsWin;
    }

    public void LoseCoins(int CoinsLose){
        this.Coins -= CoinsLose;
    }

    public void WinXP(int Xp){
        this.Xp += Xp;
    }

    public void UpLevel(){

        int experienceRequired = (this.PlayerLevel + 1) * 2000;
    
        if (this.Xp >= experienceRequired)
        {
            this.PlayerLevel++; 
            this.Xp -= experienceRequired;
        }
    }
    */

    public override string ToString()
    {
        return $"Id: {PlayerId}, Nome: {PlayerName}, Level: {PlayerLevel}, Saldo: {Balance}, Moedas: {Coins}, Mana: {Mana}, Xp: {Xp}, Personagens: {Personagem}";
    }

}