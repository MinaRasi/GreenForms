using System.ComponentModel.DataAnnotations;

public class Patient
{   [Key]
    public int Id { get; set; }
    public string Name  { get; set; }
    public string MiddleName  { get; set; }
    public string LastName  { get; set; }
    public string PatientID  { get; set; }
}