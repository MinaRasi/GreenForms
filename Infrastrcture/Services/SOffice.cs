public class SOffice:IOffice
{
    private readonly Context db;
    public SOffice(Context _db)
    {
        db=_db;
    }

    public bool AddOffice(VmOffice off)
    {
        if(db.offices.Count() != 0) return false;

        Office t1=new Office();
        t1.Address=off.Address;
        t1.Email=off.Email;
        t1.NameOffice=off.NameOffice;
        t1.PhoneNumber=off.PhoneNumber;
        
        db.offices.Add(t1);
        db.SaveChanges();
        return true;
    }




    public List<VmOffice> ShowOffice()
    {
       List<VmOffice> v1=new List<VmOffice>();
       
       foreach (var item in db.offices)
       {
         VmOffice of=new VmOffice();

         of.Id=item.Id;
         of.Address=item.Address;
         of.Email=item.Email;
         of.NameOffice=item.NameOffice;
         of.PhoneNumber=item.PhoneNumber;
         
         v1.Add(of);
       }
       return v1;
    }
        public VmOffice GetOfficeById(int id)
    {
        var find=db.offices.Where(a=>a.Id==id).SingleOrDefault();

        VmOffice o=new VmOffice();
        
        o.Id=find.Id;
        o.Address=find.Address;
        o.Email=find.Email;
        o.NameOffice=find.NameOffice;
        o.PhoneNumber=find.PhoneNumber;
        
        return o;
    }

    public bool EditOffice(VmOffice off)
    {
       var find=db.offices.Find(off.Id);

       find.Id=off.Id;
       find.Address=off.Address;
       find.Email=off.Email;
       find.NameOffice=off.NameOffice;
       find.PhoneNumber=off.PhoneNumber;

       db.offices.Update(find);
       db.SaveChanges();

       return true;
    }

    public bool DeleteOffice(int id)
    {
        var del=db.offices.Find(id);
        db.Remove(del);
        db.SaveChanges();
        return true;
    }
}