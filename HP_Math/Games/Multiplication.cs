namespace HP_Math.Games;

internal class Multiplication : Game, IGame
{
    public Revise? Revise { get => base.InternalRevise; }

    public Multiplication(User user) : base(user, GameType.Multiplication)
    {
    }

    public void CheckAnswer()
    {
        bool correct = Answer == FirstNumber * SecondNumber;
        DisplayAndRecordAnswer(correct);
    }

    public void GenerateProblem()
    {
        if (QuestionNumber == 0)
            StartTime = DateTime.Now;

        GenerateBasicNumbers();

        Console.WriteLine($"What is {FirstNumber} * {SecondNumber}?");

        Answer = int.Parse(Console.ReadLine() ?? "0");
    }

    bool IGame.Continue()
    {
        return Continue();
    }
}
