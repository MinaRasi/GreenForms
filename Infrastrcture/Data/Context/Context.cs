using Microsoft.EntityFrameworkCore;

public class Context:DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<RequestForm> RequestForms { get; set; }
    public DbSet<TranslateLang> TranslateLangs { get; set; }
    public DbSet<Office> offices { get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder db)
    {
        db.UseSqlServer("data source=.;initial catalog=DbQuestionnaire1;integrated security=true");
    }
}