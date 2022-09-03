using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int Id  { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string State { get; set; }
    public string NationalCode { get; set; }
    public string Question { get; set; }
    public DateTime Date { get; set; }
    public bool Active { get; set; }
    
    
}