namespace HP_Math.Data;

internal class UserRepo
{
    MContext Context { get; set; }

    public UserRepo()
    {
        Context = new MContext();
        Context.Database.EnsureCreated();
    }

    internal IEnumerable<User> GetAllUsers()
    {
        return Context.Users.ToList();
    }

    internal User GetOrAddUser(User user)
    {
        var existingUser = Context.Users.FirstOrDefault(u => u.Name == user.Name &&
                                                             u.House == user.House &&
                                                             u.Year == user.Year);
        if (existingUser != null) 
            return existingUser;

        Context.Users.Add(user);
        Context.SaveChanges();
        return user;
    }

    internal void RemoveAllUsers()
    {
        Context.Users.RemoveRange(Context.Users);
        Context.SaveChanges();
    }
}