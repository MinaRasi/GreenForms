using System.ComponentModel.DataAnnotations;

public class TranslateLang
{
    [Key]
 public int Id { get; set; }
 public string Lang { get; set; }
 public int RequestFormId { get; set; }
 
 
 
}