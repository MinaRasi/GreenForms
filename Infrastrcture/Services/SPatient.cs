public class SPatient : IPatient
{
    private readonly Context db;
    public SPatient(Context _db)
    {
        db=_db;
    }
    public bool AddPatient(VmPatient p)
    {
        Patient p1=new Patient();
        p1.Name=p.Name;
        p1.MiddleName=p.MiddleName;
        p1.LastName=p.LastName;
        p1.PatientID=p.PatientID;
        
        db.Patients.Add(p1);
        db.SaveChanges();
        return true;
    }

    public List<VmPatient> ShowPatient()
    {
        List<VmPatient>p1=new List<VmPatient>();
        foreach (var item in db.Patients)
        {
            VmPatient p=new VmPatient();
            p.Id=item.Id;
            p.Name=item.Name;
            p.MiddleName=item.MiddleName;
            p.LastName=item.LastName;
            p.PatientID=item.PatientID;
            p1.Add(p);
        }
        return p1;
    }
}