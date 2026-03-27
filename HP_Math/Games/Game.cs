
namespace HP_Math.Games;

abstract class Game
{
    internal Revise? InternalRevise { get; set; }
    internal int FirstNumber { get; set; }
    internal int SecondNumber { get; set; }
    internal int Answer { get; set; }
    internal int QuestionNumber { get; set; }
    public DateTime StartTime { get; set; }

    internal Game(User user, GameType gameType)
    {
        InternalRevise = new(user, gameType);
    }

    internal void GenerateBasicNumbers()
    {
        var random = new Random();

        var top = InternalRevise?.UserNav?.Year switch
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
            Console.WriteLine("Correct!");
            InternalRevise?.Score += 1;
        }
        else
        {
            Console.WriteLine("Incorrect.");
        }
        QuestionNumber++;

        if(QuestionNumber == InternalRevise?.QuestionTotal)
        {
            var percentage = (double)InternalRevise.Score / InternalRevise.QuestionTotal * 100;
            InternalRevise.Grade = GradeHelper.GetGrade((int)percentage);
            InternalRevise.TimeTaken = DateTime.Now - StartTime;
            Console.WriteLine($"Great revise {InternalRevise?.UserNav?.House}! You got : {InternalRevise?.Grade}. It took you {InternalRevise?.TimeTaken.TotalSeconds.ToString("F1")} seconds to complete.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    internal bool Continue()
    {
        if (QuestionNumber < InternalRevise?.QuestionTotal)
            return true;
        else
            return false;
    }

    internal void GetAnswer()
    {
        string? input = null;
        var validated = false;
        do
        {
            input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int result))
            {
                Answer = result;
                validated = true;
            }
            else
                Console.WriteLine("Your answer must be an integer. Please try again.");
        }
        while (!validated) ;
    }
}
