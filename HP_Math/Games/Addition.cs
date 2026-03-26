namespace HP_Math.Games;

internal class Addition : Game, IGame
{
    public Revise? Revise { get => base.InternalRevise; }

    public Addition(User user) : base(user, GameType.Addition)
    {
    }

    public void CheckAnswer()
    {
        bool correct = Answer == FirstNumber + SecondNumber;
        DisplayAndRecordAnswer(correct);
    }

    public void GenerateProblem()
    {
        if(QuestionNumber == 0)
            StartTime = DateTime.Now;

        GenerateBasicNumbers();

        Console.WriteLine($"What is {FirstNumber} + {SecondNumber}?");
        
        GetAnswer();
    }

    bool IGame.Continue()
    {
        return Continue();
    }
}
