
public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Jersey { get; set; }
}

public interface IHockeyPlayerRepository
{
    void AddPlayer(Player player);
    void UpdatePlayer(Player player);
    List<Player> ListAllPlayers();
}

public class App
{
    public void Run()
    {
        
    }
}