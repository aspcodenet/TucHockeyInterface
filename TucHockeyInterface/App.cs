
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

public class FileHockeyRepository : IHockeyPlayerRepository
{
    public void AddPlayer(Player player)
    {
        var all = ListAllPlayers();
        int last = 0;
        foreach (var p in all)
            if (p.Id > last)
                last = p.Id;
        last = last + 1;
        player.Id = last;
        all.Add(player);
        Save(all);
    }

    private void Save(List<Player> all)
    {
        var stringar = new List<string>();
        foreach (var p in all)
            stringar.Add($"{p.Id},{p.Name},{p.Age},{p.Jersey}");
        File.WriteAllLines("players.txt", stringar);
    }

    public void UpdatePlayer(Player player)
    {
        var all = ListAllPlayers();
        foreach (var p in all)
            if (p.Id == player.Id)
            {
                p.Age = player.Age;
                p.Jersey = player.Jersey;
                p.Name = player.Name;
            }

        Save(all);

    }

    public List<Player> ListAllPlayers()
    {
        var list = new List<Player>();
        if (!File.Exists("players.txt")) return list;
        foreach (var line in File.ReadLines("players.txt"))
        {
            var parts = line.Split(",");
            var player = new Player();
            player.Id = Convert.ToInt32(parts[0]);
            player.Name = parts[1];
            player.Age = Convert.ToInt32(parts[2]);
            player.Jersey = Convert.ToInt32(parts[3]);
            list.Add(player);
        }

        return list;
    }

}

public class App
{
    public void Run()
    {
        IHockeyPlayerRepository repository = new FileHockeyRepository();
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
                Console.WriteLine("Namn:");
                player.Name = Console.ReadLine();
                Console.WriteLine("Age:");
                player.Age = Convert.ToInt32(Console.ReadLine());
                repository.AddPlayer(player);
            }
        }
    }
}