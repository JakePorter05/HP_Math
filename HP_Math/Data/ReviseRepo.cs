namespace HP_Math.Data;

public class ReviseRepo
{
    MContext Context { get; set; }

    public ReviseRepo()
    {
        Context = new MContext();
        Context.Database.EnsureCreated();
    }

    internal IEnumerable<Revise> GetAllRevisesWUsers()
    {
        return Context.Revises.Include(x => x.UserNav)
                              .ToList();
    }

    internal IEnumerable<Revise> GetAllRevisesForUser(User user)
    {
        return Context.Revises.Where(x => x.UserId == user.Id)
                              .Include(x => x.UserNav)
                              .ToList();
    }

    internal Revise? AddRevise(Revise? revise)
    {
        if (revise == null) return null;

        if (revise.UserId != 0)
            revise.UserNav = null;

        Context.Revises.Add(revise);
        Context.SaveChanges();
        return revise;
    }

    internal void RemoveAllRevises()
    {
        Context.Revises.RemoveRange(Context.Revises);
        Context.SaveChanges();
    }
}
