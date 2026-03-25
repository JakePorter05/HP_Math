namespace HP_Math.Helpers;

internal class YearHelper
{
    string PrintYear(int year)
    {
        switch (year)
        {
            case 1:
                return "1st";
            case 2:
                return "2nd";
            case 3:
                return "3rd";
            case 4:
            case 5:
            case 6:
            case 7:
                return $"{year}th";
            default:
                return "1st";
        }
    }
}
