namespace HP_Math.Services;

internal class GreetingService
{
    public User? User { get; set;  }

    public GreetingService(User? user)
    {
        User = user;
    }

    internal void GetName()
    {
        Console.Clear();
        Console.WriteLine("What is your Name?");
        string? name = Console.ReadLine();
        User?.Name = name ?? "";
    }

    internal void GetYear()
    {
        Console.Clear();
        Console.WriteLine($"What year are you in {User?.Name}? (1-7)\nIll make sure to amp up the difficulty by your year. \nWe must be ready for OWL's, and NEWT's.");
        var year = Console.ReadLine();
        User?.Year = int.Parse(year ?? "1");
    }

    internal void GetHouse()
    {
        Console.Clear();
        Console.WriteLine($"Welcome {PrintYear(User?.Year ?? 1)} year. What house are you in?");
        Console.WriteLine($"""
                            G - {Houses.Gryffindor}
                            H - {Houses.Hufflepuff}
                            R - {Houses.Ravenclaw}
                            S - {Houses.Slytherin}
                           """);
        var house = Console.ReadLine();
        Console.Clear();

        switch (house?.Trim().ToLower())
        {
            case "g":
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Gryffindor! Brave and Chivalrous! Let's see how brave you are with some math problems!");
                User?.House = Houses.Gryffindor;
                break;
            case "h":
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hufflepuff! Loyal and Kind! Let's see how loyal you are with some math problems!");
                User?.House = Houses.Hufflepuff;
                break;
            case "r":
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Ravenclaw! Wise and Creative! Let's see how wise you are with some math problems!");
                User?.House = Houses.Ravenclaw;
                break;
            case "s":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Slytherin! Ambitious and Cunning! Let's see how ambitious you are with some math problems!");
                User?.House = Houses.Slytherin;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid house selection. Defaulting to Gryffindor.");
                User?.House = Houses.Gryffindor;
                break;
        }
    }

    string PrintYear(int year)
    {
        switch (year)
        {
            case 1:
                return "1st";
            case 2:
                return "2nd";
            case 3:
                return "3rd";
            case 4:
            case 5:
            case 6:
            case 7:
                return $"{year}th";
            default:
                return "1st";
        }
    }
}