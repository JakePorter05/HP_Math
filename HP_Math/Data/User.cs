namespace HP_Math.Data;

internal class User
{
    public int Id { get; set; } 
    public string Name { get; set; } = "";
    public string House { get; set; } = "";
    public int Year { get; set; } = 0;

    ICollection<Revise> Revises { get; set; } = [];
}
