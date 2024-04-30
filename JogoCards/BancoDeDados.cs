using Microsoft.EntityFrameworkCore;

public class BancoDeDados : DbContext
{
    public BancoDeDados(
        DbContextOptions<BancoDeDados> options)
        : base(options) { }

    // Configuração do banco de dados MySQL
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseMySQL("server=localhost;port=3306;database=JogoCards;user=root;password=Fabricio123@");
    }

    public DbSet<Card> Cards { get; set; }
    public DbSet<Personagem> Personagens { get; set; }
    public DbSet<Player> Players { get; set; }
    
}