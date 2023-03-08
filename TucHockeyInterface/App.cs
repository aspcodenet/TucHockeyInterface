
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
        IHockeyPlayerRepository repository;
        while (true)
        {
            Console.WriteLine("1. Add player");
            Console.WriteLine("2. List players");
            Console.WriteLine("3. Avsluta");
            var sel = Console.ReadLine();
            if (sel == "3") break;
            if (sel == "2")
            {
                foreach (var p in repository.ListAllPlayers())
                {
                    Console.WriteLine($" {p.Name} {p.Age}");
                }
            }

            if (sel == "1")
            {
                Player player = new Player();
                Console.WriteLine("Namn:")
                player.Name = Console.ReadLine();
                Console.WriteLine("Age:")
                player.Age = Convert.ToInt32(Console.ReadLine());
                repository.AddPlayer(player);
            }
        }
    }
}