namespace HP_Math.Data;

internal class MContext : DbContext
{
    internal DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=HP_Math.db");
    }
}