namespace HP_Math.Games;

internal interface IGame 
{
    Revise? Revise { get; }
    void GenerateProblem();
    void CheckAnswer();
    bool Continue();
}
