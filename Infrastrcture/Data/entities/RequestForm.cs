using System.ComponentModel.DataAnnotations;

public class RequestForm
{
    [Key]
    public int Id { get; set; }
    public string Url { get; set; }
    public string PrimaryLang { get; set; }
    public bool Status { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string FormName { get; set; }
    public string FileName { get; set; }
    
}