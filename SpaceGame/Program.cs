using System;

public class Player
{
    protected int MinHealth;
    protected int MaxHealth;
    protected int MinDamage;
    protected int MaxDamage;

    public int Damage
    {
        get;
        protected set;
    }

    public bool CanAddGamePoints;

    public int Health;

    public int GamePoints;

    public void AddPersonalPoints()
    {
        GamePoints += new Random().Next(1, 7);
    }

    public void ResetGamePoints()
    {
        GamePoints = 0;
    }

    public void Initialization()
    {
        Random random = new Random();
        Health = random.Next(MinHealth, MaxHealth);
        Damage = random.Next(MinDamage, MaxDamage);
    }

    public void GetDamage(int countOfHits)
    {
        Health -= Damage * countOfHits;
    }
    public void CheckIfOutOfBounds()
    {
        if (GamePoints > 12)
            GamePoints = 6;
    }
    public void OutPutStats()
    {
        Console.WriteLine($"{Health}, {Damage}, {GamePoints}");
    }
}

public class HumanPlayer : Player
{
    public HumanPlayer()
    {
        MinHealth = 80;
        MaxHealth = 101;
        MinDamage = 8;
        MaxDamage = 18;

        Initialization();
    }
}

public class ComputerPlayer : Player
{
    public ComputerPlayer()
    {
        MinHealth = 80;
        MaxHealth = 81;
        MinDamage = 7;
        MaxDamage = 16;

        Initialization();
    }
}

public class Program
{
    static bool fight = true;
    public static void Main()
    {
        Player player = new HumanPlayer();
        Player enemy = new ComputerPlayer();

        player.OutPutStats();
        enemy.OutPutStats();

        Console.WriteLine("/ / / / Игра начата / / / /");

        while (fight)
        {
            player.ResetGamePoints();
            enemy.ResetGamePoints();

            while (CanAddGamePoints(player) && CanAddGamePoints(enemy))
            {
                player.AddPersonalPoints();
                enemy.AddPersonalPoints();
            }

            player.CheckIfOutOfBounds();
            enemy.CheckIfOutOfBounds();

            var attacked = WhoGetDamage(player, enemy);
            attacked?.GetDamage(CountGamePoints(player, enemy));

            player.OutPutStats();
            enemy.OutPutStats();

            Console.WriteLine("Turn ended");
            Console.WriteLine(" ");

            fight = CheckIsFightContinue(player, enemy);
        }

        Console.WriteLine("/ / / / Игра окончена / / / /");

        player.OutPutStats();
        enemy.OutPutStats();

        Console.WriteLine($"Проигравший: {WhoGetDamage(player, enemy)}");

        Console.ReadKey();
    }

    static int CountGamePoints(Player player, Player bot)
    {
        if (player.GamePoints > bot.GamePoints)
        {
            return player.GamePoints - bot.GamePoints;
        }
        else if (player.GamePoints < bot.GamePoints)
        {
            return bot.GamePoints - player.GamePoints;
        }
        else
        {
            return 0;
        }
    }
    static Player WhoGetDamage(Player player, Player bot)
    {
        if (player.GamePoints > bot.GamePoints)
        {
            return bot;
        }
        else if (player.GamePoints < bot.GamePoints)
        {
            return player;
        }
        else
        {
            return null;
        }
    }
    static bool CheckIsFightContinue(Player player, Player bot)
    {
        if (player.Health <= 0 || bot.Health <= 0)
        {
            return false;
        }
        else return true;
    }
    static bool CanAddGamePoints(Player currentPlayer)
    {
        if (currentPlayer.GamePoints >= 9)
        {
            return false;
        }
        else return true;
    }
}