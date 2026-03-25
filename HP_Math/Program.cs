Console.ResetColor();
Console.WriteLine("Lets Pratice our Math Skills! Harry Potter Style...\nPress Any key to start.");
Console.ReadKey();

var user = new User();  

var greetingService = new GreetingService(user);
greetingService.GetName();
greetingService.GetYear();
greetingService.GetHouse();

Console.WriteLine($"Press any key to Enter {user?.House} common room and start your practice {user?.Name}...");
Console.ReadKey();

var continueGame = true;
do
{
    Console.Clear();
    Console.WriteLine("A : Addition");
    Console.WriteLine("S : Subtraction");
    Console.WriteLine("M : Multiplication");
    Console.WriteLine("D : Division");
    Console.WriteLine("V : View High Scores");
    Console.WriteLine("E : Exit");
    var choice = Console.ReadLine();

    IGame? Game = null;

    switch (choice?.Trim().ToLower())
    {
        case "a":
            Game = new Addition(user);
            break;
            case "s":
                Game = new Subtraction(user);
            break;
            case "m":
                Game = new Multiplication(user);
            break;
            case "d":
                Game = new Division(user);
            break;
            case "v":
                ShowHighScores();
            break;
            case "e":
                Console.WriteLine($"Your High Score is {user?.HighScore} points! You finished {user?.TotalProblemsAttempted} problems.\nThanks for playing!\n\nPress any key to exit.");
                Console.ReadKey();
            continueGame = false;
            break;
        default:
            break;
    }

    if (Game != null)
    {
        while (!Game.ContinueOrExit()) 
        { 
            Game.GenerateProblem();
            Game.CheckAnswer();
        }
    }

} while (continueGame);