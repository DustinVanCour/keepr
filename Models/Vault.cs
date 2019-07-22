using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Vault
  {
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string description { get; set; }
    public string UserId { get; set; }
  
  }
}
