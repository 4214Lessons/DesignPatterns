namespace Flyweight;

abstract class Player
{
    public string? Name { get; set; }
    public int AttackPoint { get; set; }
    public short Health { get; set; }

    public abstract void Display();
}


class Archer : Player
{
    public Archer()
    {
        Name = "Archer";
        AttackPoint = 95;
        Health = 480;
    }

    public override void Display()
    {
        Console.WriteLine("Archer created");
    }
}

class Warrior : Player
{
    public Warrior()
    {
        Name = "Warrior";
        AttackPoint = 80;
        Health = 650;
    }

    public override void Display()
    {
        Console.WriteLine("Warrior created");
    }
}




class FlyWeightFactory
{
    private Dictionary<string, Player?> _units = new();

    public Player? GetUnit(string key)
    {
        Player? unit;


        if (_units.ContainsKey(key))
            unit = _units[key];
        else
        {
            unit = key switch
            {
                "Archer" => new Archer(),
                "Warrior" => new Warrior(),
                _ => null
            };

            _units.Add(key, unit);
        }

        return unit;
    }
}


class Program
{
    static void Main()
    {
        FlyWeightFactory factory = new();
        Player? player;

        for (int i = 0; i < 10000000; i++)
        {
            // player = new Archer();


            player = factory?.GetUnit("Archer");
            // player = factory?.GetUnit("Warrior");

            // Console.WriteLine(player?.GetHashCode());
        }


        Console.WriteLine("Terminated");
        Console.ReadKey();
    }
}