namespace HP_Math.Helpers;

internal static class Grades
{
    internal const string Outstanding = "Outstanding";
    internal const string ExceedsExpectations = "Exceeds Expectations";
    internal const string Acceptable = "Acceptable";
    internal const string Poor = "Poor";
    internal const string Dreadful = "Dreadful";
    internal const string Troll = "Troll";

    internal static string GetGrade(int score)
    {
        if (score >= 90)
            return Outstanding;
        else if (score >= 80)
            return ExceedsExpectations;
        else if (score >= 70)
            return Acceptable;
        else if (score >= 60)
            return Poor;
        else if (score >= 50)
            return Dreadful;
        return Troll;
    }
}
