namespace HP_Math.Services;

internal class ReviseService
{
    internal User user { get; set; }
    internal ReviseRepo reviseRepo { get; set; }

    internal ReviseService(User user)
    {
        this.user = user;
        reviseRepo = new ReviseRepo();
    }

    internal void ShowLast50()
    {
        Console.Clear();
        var users = reviseRepo.GetAllRevisesWUsers();
        var topUsers = users.OrderByDescending(u => u.Date).Take(50);

        Console.WriteLine("Revise History:");
        Console.WriteLine("----------------------------------------------------------------");
        foreach (var item in topUsers)
        {
            Console.WriteLine($"{item.UserNav?.Name} - from {item.UserNav?.House} - {item.Type} - {item.Grade} - in {item.TimeTaken.TotalSeconds.ToString("F1")}");
        }
        Console.WriteLine("----------------------------------------------------------------");

        Console.WriteLine("\nPress any key to return to the menu.\nType Clear to reset high scores.");
        var input = Console.ReadLine();
        if (input?.Trim().ToLower() == "clear")
        {
            reviseRepo.RemoveAllRevises();
            Console.WriteLine("High scores have been reset. Press any key to return to the menu.");
            Console.ReadKey();
        }
    }

    internal void ShowRevisesForStudent()
    {
        Console.Clear();
        var revises = reviseRepo.GetAllRevisesForUser(user);
        if (revises.Any())
        {
            Console.WriteLine("Revise History:");
            Console.WriteLine("----------------------------------------------------------------");
            foreach (var item in revises)
            {
                Console.WriteLine($"{item.UserNav?.Name} - from {item.UserNav?.House} - {item.Type} - {item.Grade} - in {item.TimeTaken.TotalSeconds.ToString("F1")}");
            }
            Console.WriteLine("----------------------------------------------------------------");
        }
        else
        {
            Console.WriteLine($"No revises found for student: {user.Name}");
        }
        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }

    internal void ShowMenu()
    {
        var process = true;
        do
        {
            Console.Clear();
            Console.WriteLine("T : Show Last 50 Revises");
            Console.WriteLine("U : Get Revises for a Student");
            Console.WriteLine("E : Exit");
            var choice = Console.ReadLine();

            switch (choice?.ToLower().Trim())
            {
                case "t":
                    ShowLast50();
                    break;
                case "u":
                    ShowRevisesForStudent();
                    break;
                case "e":
                    Console.WriteLine($"Returning to main menu...\n\nPress any key to continue.");
                    Console.ReadKey();
                    process = false;
                    break;
                default:
                    Console.WriteLine("Please select a valid option. Press any key to continue...");
                    break;
            }
        } while (process);
        
    }
}
