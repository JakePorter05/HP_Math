using System.Runtime.InteropServices;

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
        while (string.IsNullOrEmpty(year) || !int.TryParse(year, out _))
        {
            Console.WriteLine("Please enter a valid year between 1 and 7.");
            year = Console.ReadLine();
        }
        User?.Year = int.Parse(year ?? "1");
    }

    internal void GetHouse()
    {
        var process = true;
        do
        {
            Console.Clear();
            Console.WriteLine($"Welcome {YearHelper.PrintYear(User?.Year ?? 1)} year. What house are you in?");
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
                    Console.WriteLine("Please Enter a valid house.");
                    break;
            }

            if(User?.House != null)
            {
                process = false;
            }
        } while (process);
        
    }
}