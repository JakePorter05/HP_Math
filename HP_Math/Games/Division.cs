namespace HP_Math.Games;

internal class Division : Game, IGame
{
    public Division(User? user) : base(user)
    {
    }

    public void CheckAnswer()
    {
        bool correct = Answer == FirstNumber / SecondNumber;
        DisplayAndRecordAnswer(correct);
    }

    public void GenerateProblem()
    {
        var random = new Random();
        do
        {
            if (User?.Year < 5)
            {
                FirstNumber = random.Next(1, 50);
                SecondNumber = random.Next(1, 50);
            }
            else
            {
                FirstNumber = random.Next(1, 99);
                SecondNumber = random.Next(1, 99);
            }
        }
        while (FirstNumber % SecondNumber != 0);

        Console.WriteLine($"What is {FirstNumber} + {SecondNumber}?");

        Answer = int.Parse(Console.ReadLine() ?? "0");
    }

    bool IGame.ContinueOrExit()
    {
        return ContinueOrExit();
    }
}
