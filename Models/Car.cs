using System.ComponentModel.DataAnnotations;

namespace gregsdotnet.Models
{
  public class Car
  {
    public int Id { get; set; }
    [Required]
    public string Make { get; set; }
    [Required]
    public string Model { get; set; }
    public int Year { get; set; }
    [Required]
    public double Price { get; set; }
  }
}
