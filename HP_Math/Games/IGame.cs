namespace HP_Math.Games;

internal interface IGame 
{
    void GenerateProblem();
    void CheckAnswer();
    bool ContinueOrExit();
}
