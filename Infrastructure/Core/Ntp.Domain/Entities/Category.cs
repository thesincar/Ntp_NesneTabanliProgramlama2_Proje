using Ntp.Domain.Common;

namespace Ntp.Domain.Entities;

public class Category : EntityBase
{
    public Category()
    {

    }

    public Category(string name, int subCategoryId, int sort)
    {
        Name = name;
        SubCategoryId = subCategoryId;
        Sort = sort;
    }

    public string Name { get; set; }
    public int SubCategoryId { get; set; }
    public int Sort { get; set; }


    public ICollection<Detail> Details { get; set; }
    public ICollection<ProductCategory> ProductCategories { get; set; }

}