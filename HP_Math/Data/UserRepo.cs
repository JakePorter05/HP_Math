namespace HP_Math.Data;

public class UserRepo
{
    MContext Context { get; set; }

    public UserRepo()
    {
        Context = new MContext();
        Context.Database.EnsureCreated();
    }

    internal async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await Context.Users.ToListAsync();
    }

    internal async Task AddUserAsync(User user)
    {
        Context.Users.Add(user);
        await Context.SaveChangesAsync();
    }

    internal async Task RemoveAllAsync()
    {
        Context.Users.RemoveRange(Context.Users);
        await Context.SaveChangesAsync();
    }
}
