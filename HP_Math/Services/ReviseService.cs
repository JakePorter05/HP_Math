namespace HP_Math.Services;

internal class ReviseService
{
    ReviseRepo reviseRepo { get; set; }

    internal ReviseService()
    {
        reviseRepo = new ReviseRepo();
    }

    internal void ShowTop50()
    {
        Console.Clear();
        var users = reviseRepo.GetAllRevisesWUsers();
        var topUsers = users.OrderByDescending(u => u.Date).Take(50);

        foreach (var item in topUsers)
        {
            Console.WriteLine($"{item.UserNav?.Name} - from {item.UserNav?.House} - {item.Grade} - in {item.TimeTaken}");
        }

        Console.WriteLine("\nPress any key to return to the menu.\nType Clear to reset high scores.");
        var input = Console.ReadLine();
        if (input?.Trim().ToLower() == "clear")
        {
            reviseRepo.RemoveAllRevises();
            Console.WriteLine("High scores have been reset. Press any key to return to the menu.");
            Console.ReadKey();
        }
    }

    internal void ShowMenu()
    {
        throw new NotImplementedException();
    }
}
