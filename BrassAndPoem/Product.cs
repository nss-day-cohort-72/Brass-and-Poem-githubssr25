//create your Product class here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ProductType ProductType { get; set; }

    public int ProductTypeId { get; set;}



    // Default parameterless constructor
    public Product() { }

    // Constructor with DateStocked
    public Product(string name, decimal price, int productTypeId)
    {
        Name = name;
        Price = price;
        ProductTypeId = productTypeId;
    }

    // Updated ToString() method to include DateStocked and DaysOnShelf
    // public override string ToString()
    // {
    //     return $"{Name} - {ProductType.Name} - ${Price}";
    // }
}
