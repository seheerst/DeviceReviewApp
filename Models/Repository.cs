using Microsoft.AspNetCore.Http.HttpResults;

namespace DeviceReviewApp.Models;

public class Repository
{
    private static readonly List<Product> _products = new();
    private static readonly List<Category> _categories = new();

    static Repository()
    {
          _categories.Add(new Category(){CategoryId = 1, Name = "Telefon"}); 
          _categories.Add(new Category(){CategoryId = 2, Name = "Bilgisayar"});
          
          _products.Add(new Product(){ProductId = 1, Name = "Iphone 14", Price = "40000₺",IsActive = true, CategoryId = 1,Image = "1.jpg"});
          _products.Add(new Product(){ProductId = 2, Name = "Iphone 13", Price = "30000₺",IsActive = true, CategoryId = 1,Image = "2.jpg"});
          _products.Add(new Product(){ProductId = 3, Name = "Iphone 12", Price = "20000₺",IsActive = true, CategoryId = 1,Image = "3.jpg"});
          _products.Add(new Product(){ProductId = 4, Name = "Iphone 11", Price = "18000₺",IsActive = true, CategoryId = 1,Image = "4.jpg"});
          _products.Add(new Product(){ProductId = 5, Name = "Macbook Air", Price = "25000₺",IsActive = true, CategoryId = 2,Image = "5.jpg"});
          _products.Add(new Product(){ProductId = 6, Name = "Macbook Pro", Price = "30000₺",IsActive = true, CategoryId = 2,Image = "6.jpg"});
    }

    
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

    public static void CreateProduct(Product entity)
    {
        entity.ProductId = _products.Count + 1;
        _products.Add(entity);
    }
}