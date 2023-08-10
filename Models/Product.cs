namespace DeviceReviewApp.Models;

public class Product
{
    public  int ProductId { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public string Price { get; set; }= string.Empty;

    public string Image { get; set; } = string.Empty;
    
    public bool IsActive { get; set; }
    
    public int CategoryId { get; set; }
}