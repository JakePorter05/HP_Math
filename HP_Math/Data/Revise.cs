namespace HP_Math.Data;

internal class Revise
{
    public int Id { get; set; }
    public int Score { get; set; } = 0; 
    public int QuestionTotal { get; set; } = 4;
    public string Type { get; set; } = "";  
    public DateTime Date { get; set; } = DateTime.Now;
    public TimeSpan TimeTaken { get; set; } = TimeSpan.Zero;
    public string Grade { get; set; } = "";

    public int UserId { get; set; }
    public User? UserNav { get; set; }

    public Revise() { }
    public Revise(User user, string gameType)
    {
        UserId = user.Id;
        UserNav = user;
        QuestionTotal += user?.Year ?? 1;
        Type = gameType;
    }
}
