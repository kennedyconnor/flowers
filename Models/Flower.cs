using System.ComponentModel.DataAnnotations;

namespace flowers.Models
{
  public class Flower
  {
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Color { get; set; }
  }
}