public class SUser : IUser
{
    private readonly Context db;
    public SUser(Context _db)
    {
        db = _db;
    }
    public bool adduser(VmUser u)
    {
        var code = db.Users.Any(x=>x.NationalCode==u.NationalCode);
        if (code == false)
        {
            User user = new User();

                user.FirstName = u.FirstName;
                user.MiddleName = u.MiddleName;
                user.LastName = u.LastName;
                user.Gender = u.Gender;
                user.Question = u.Question;
                user.Date = u.Date;
                user.Active = true;
                user.NationalCode = u.NationalCode;
                user.State = u.State;
                db.Users.Add(user);
                db.SaveChanges();  
                return true;           
        }
        else
        {
            return false;
            
        }
      
    }
    public bool Deluser(int id)
    {
        var q = db.Users.Find(id);
        db.Users.Remove(q);
        db.SaveChanges();
        return true;
    }
    public bool EditUser(VmUser m)
    {
        var q = db.Users.Where(a => a.Id == m.Id).FirstOrDefault();
        q.Id = m.Id;
        q.FirstName = m.FirstName;
        q.MiddleName = m.MiddleName;
        q.LastName = m.LastName;
        q.Gender = m.Gender;
        q.Question = m.Question;
        q.NationalCode = m.NationalCode;
        q.State = m.State;
        db.Users.Update(q);
        db.SaveChanges();
        return true;
    }

    public VmUser GetId(int id)
    {
        var q = db.Users.Find(id);
        VmUser user = new VmUser()
        {
            FirstName = q.FirstName,
            MiddleName = q.MiddleName,
            LastName = q.LastName,
            NationalCode = q.NationalCode,
            Gender = q.Gender,
            State = q.State,
            Date = q.Date
        };
        return user;
    }

    public List<VmUser> Showuser()
    {
        List<VmUser> List = new List<VmUser>();
        foreach (var item in db.Users.OrderByDescending(a => a.Id))
        {
            VmUser u = new VmUser();
            u.Id = item.Id;
            u.Date = item.Date;
            u.FirstName = item.FirstName;
            u.LastName = item.LastName;
            u.Gender = item.State;
            u.NationalCode = item.NationalCode;
            u.Question = item.Question;
            u.Active = item.Active;
            u.State = item.State;
            u.MiddleName = item.MiddleName;
            List.Add(u);
        }
        return List;
    }
    public bool ActiveUser(int id)
    {
        var act = db.Users.Find(id);
        if (act.Active == true)
        {
            act.Active = false;
        }
        else
        {
            act.Active = true;
        }
        db.Users.Update(act);
        db.SaveChanges();
        return true;
    }
    public int GetUserCount()
    {
       return db.Users.Count();
    }
}