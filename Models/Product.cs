using System.ComponentModel.DataAnnotations;

namespace DeviceReviewApp.Models;

public class Product
{
    
    public  int ProductId { get; set; }

    [Required]
    public string? Name { get; set; }
    
    [Required]
    public string? Price { get; set; }

    [Required]
    public string? Image { get; set; }
    
    public bool IsActive { get; set; }
    
    [Required]
    public int? CategoryId { get; set; }
}