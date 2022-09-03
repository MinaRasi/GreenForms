public class SDoctor : IDoctor
{
    private readonly Context db;

    public SDoctor(Context _db)
    {
        db = _db;
    }

    public bool AddDoctor(VmDoctor doc)
    {
        Doctor d = new Doctor();

        d.Firstname = doc.Firstname;
        d.Lastname = doc.Lastname;
        d.State = doc.State;
        d.City = doc.City;
        d.Gender = doc.Gender;
        d.Email = doc.Email;
        d.Password = doc.Password;
        d.Phone = doc.Phone;
        d.Street = doc.Street;

        db.Doctors.Add (d);
        db.SaveChanges();

        return true;
    }

    public List<VmDoctor> ShowDoctor()
    {
        List<VmDoctor> doci = new List<VmDoctor>();

        foreach (var item in db.Doctors.OrderByDescending(x => x.Id))
        {
            VmDoctor d = new VmDoctor();
            d.Id=item.Id;
            d.Firstname = item.Firstname;
            d.Lastname = item.Lastname;
            d.City = item.City;
            d.Email = item.Email;
            d.Password = item.Password;
            d.Phone = item.Phone;
            d.Gender = item.Gender;
            d.State = item.State;
            d.Street = item.Street;

            doci.Add (d);
        }
        return doci;
    }

    public VmDoctor GetDoctorById(int id)
    {
        var a = db.Doctors.Find(id);

        VmDoctor d = new VmDoctor();

        d.Id = a.Id;
        d.Firstname = a.Firstname;
        d.Lastname = a.Lastname;
        d.City = a.City;
        d.Email = a.Email;
        d.Password = a.Password;
        d.Phone = a.Phone;
        d.Gender = a.Gender;
        d.State = a.State;
        d.Street = a.Street;

        return d;
    }

    public bool EditDoctor(VmDoctor doc)
    {
        var a=db.Doctors.Find(doc.Id);

        a.Id=doc.Id;
        a.Firstname = doc.Firstname;
        a.Lastname = doc.Lastname;
        a.City = doc.City;
        a.Email = doc.Email;
        a.Password = doc.Password;
        a.Phone = doc.Phone;
        a.Gender = doc.Gender;
        a.State = doc.State;
        a.Street = doc.Street;
        
        db.Doctors.Update(a);
        db.SaveChanges();

        return true;
    }

    public bool DeleteDoctor(int id)
    {
        var del=db.Doctors.Find(id);
        db.Doctors.Remove(del);
        db.SaveChanges();
        return true;
    }

    public int GetCount()
    {
       return db.Doctors.Count();
    }
}
