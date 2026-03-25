
namespace HP_Math.Games;

abstract class Game
{
    internal User? User { get; set; }
    internal int FirstNumber { get; set; }
    internal int SecondNumber { get; set; }
    internal int Answer { get; set; }
    internal int QuestionNumber { get; set; } = 0;

    internal Game(User? user)
    {
        User = user;
    }

    internal void GenerateBasicNumbers()
    {
        var random = new Random();

        var top = User?.Year switch
        {
            1 => 10,
            2 => 10,
            3 => 20,
            4 => 20,
            5 => 30,
            6 => 30,
            _ => 40
        };

        FirstNumber = random.Next(1, top);
        SecondNumber = random.Next(1, top);
    }

    internal void DisplayAndRecordAnswer(bool correct)
    {
        if (correct)
        {
            Console.WriteLine("Correct!\nPress Any key for next question.");
            User?.Score += 1;
            User?.TotalProblemsAttempted += 1;
        }
        else
        {
            Console.WriteLine("Incorrect.\nPress Any Key for next question.");
        }
        Console.ReadKey();
    }

    internal bool ContinueOrExit()
    {
        if (QuestionNumber < User?.Year)
            return false;
        else
            return true;
    }
}
