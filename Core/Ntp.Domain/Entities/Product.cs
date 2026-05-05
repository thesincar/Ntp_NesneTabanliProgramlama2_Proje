using Ntp.Domain.Common;

namespace Ntp.Domain.Entities;

public class Product : EntityBase
{
    public Product()
    {

    }

    public Product(string name, int price, string description)
    {
        Name = name;
        Price = price;
        Description = description;
    }
    public string Name { get; set; }
    public int Price { get; set; }
    //public string ImageUrl { get; set; }
    public string Description { get; set; }
    public ICollection<Category> Categories { get; set; }
}
