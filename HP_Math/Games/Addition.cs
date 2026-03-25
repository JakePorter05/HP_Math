namespace HP_Math.Games;

internal class Addition : Game, IGame
{
    public Addition(User? user) : base(user)
    {
    }

    public void CheckAnswer()
    {
        bool correct = Answer == FirstNumber + SecondNumber;
        DisplayAndRecordAnswer(correct);
    }

    public void GenerateProblem()
    {
        GenerateBasicNumbers();

        Console.WriteLine($"What is {FirstNumber} + {SecondNumber}?");

        Answer = int.Parse(Console.ReadLine() ?? "0");
    }

    bool IGame.ContinueOrExit()
    {
        return ContinueOrExit();
    }
}
