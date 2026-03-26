Console.ResetColor();
Console.WriteLine("Lets Pratice our Math Skills! Harry Potter Style...\nPress Any key to start.");
Console.ReadKey();

var reviseService = new ReviseService();
var userRepo = new UserRepo();
var reviseRepo = new ReviseRepo();
var user = new User();

var greetingService = new GreetingService(user);
greetingService.GetName();
greetingService.GetYear();
greetingService.GetHouse();
user = userRepo.GetOrAddUser(user);

Console.WriteLine($"Press any key to Enter {user?.House} common room and start your practice {user?.Name}...");
Console.ReadKey();

if (user != null)
{
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
                reviseService.ShowMenu();
                break;
            case "e":
                Console.WriteLine($"Thanks for playing!\n\nPress any key to exit.");
                Console.ReadKey();
                continueGame = false;
                break;
            default:
                break;
        }

        if (Game != null)
        {
            while (Game.Continue())
            {
                Console.Clear();
                Game.GenerateProblem();
                Game.CheckAnswer();
            }
            reviseRepo.AddRevise(Game?.Revise);
        }

    } while (continueGame);
}