namespace HP_Math.Games;

internal class Division : Game, IGame
{
    public Revise? Revise { get => base.InternalRevise; }

    public Division(User user) : base(user, GameType.Division)
    {
    }

    public void CheckAnswer()
    {
        bool correct = Answer == FirstNumber / SecondNumber;
        DisplayAndRecordAnswer(correct);
    }

    public void GenerateProblem()
    {
        if (QuestionNumber == 0)
            StartTime = DateTime.Now;

        var random = new Random();
        do
        {
            if (InternalRevise?.UserNav?.Year < 5)
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

        GetAnswer();
    }

    bool IGame.Continue()
    {
        return Continue();
    }
}
