//create your ProductType class here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class ProductType
{
    public int Id { get; set; }
    public string Title { get; set; }

    public ProductType(int id, string name)
    {
        Id = id;
        Title = name;
    }

    public ProductType() {}
}
