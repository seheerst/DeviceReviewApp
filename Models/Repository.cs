namespace DeviceReviewApp.Models;

public class Repository
{
    private static readonly List<Product> _products = new();
    private static readonly List<Category> _categories = new();

    
    
    public static List<Product> Products
    {
        get
        {
            return _products;
        }
    }
    
    public static List<Category> Categories
    {
        get
        {
            return _categories;
        }
    }
}