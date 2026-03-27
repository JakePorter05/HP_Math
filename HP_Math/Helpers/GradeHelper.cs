namespace HP_Math.Helpers;

internal static class GradeHelper
{
    internal static string GetGrade(int score)
    {
        if (score >= 90)
            return Grades.Outstanding.ToString();
        else if (score >= 80)
            return Grades.Exceeds_Expectations.ToString().Replace('_', ' ');
        else if (score >= 70)
            return Grades.Acceptable.ToString();
        else if (score >= 60)
            return Grades.Poor.ToString();
        else if (score >= 50)
            return Grades.Dreadful.ToString();
        return Grades.Troll.ToString();
    }
}
