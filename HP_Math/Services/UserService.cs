namespace HP_Math.Services;

internal class UserService
{
    internal UserService()
    {

    }

    async void ShowHighScores()
    {
        Console.Clear();
        var users = await userRepo.GetAllUsersAsync();
        var topUsers = users.OrderByDescending(u => u.HighScore).Take(10);

        Console.WriteLine("Top 10 High Scores:");
        foreach (var item in topUsers)
        {
            Console.WriteLine($"{item.Name} - a {item.House} - {item.HighScore} points - ");
        }

        Console.WriteLine("\nPress any key to return to the menu.\nType Clear to reset high scores.");
        var input = Console.ReadLine();
        if (input?.Trim().ToLower() == "clear")
        {
            await userRepo.RemoveAllAsync();
            Console.WriteLine("High scores have been reset. Press any key to return to the menu.");
            Console.ReadKey();
        }
    }
}
