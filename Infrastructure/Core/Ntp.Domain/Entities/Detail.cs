using Ntp.Domain.Common;

namespace Ntp.Domain.Entities;

public class Detail : EntityBase
{
    public Detail()
    {

    }

    public Detail(string title, string value, int categoryId)
    {
        Title = title;
        Description = value;
        CategoryId = categoryId;
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
