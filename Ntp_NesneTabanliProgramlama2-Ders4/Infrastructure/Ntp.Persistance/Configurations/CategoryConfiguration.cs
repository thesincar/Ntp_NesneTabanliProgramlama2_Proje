using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ntp.Domain.Entities;

namespace Ntp.Persistance.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        Random rnd = new Random();
        Category c1 = new()
        {
            Id = 1,
            Name = "Elektronik",
            SubCategoryId = 0,
            Sort = 1,
            CreatedDate = DateTime.Now,
        };

        Category c2 = new()
        {
            Id = 2,
            Name = "Moda",
            SubCategoryId = 0,
            Sort = 2,
            CreatedDate = DateTime.Now.AddMinutes(rnd.NextInt64() * 20),
        };

        Category c3 = new()
        {
            Id = 3,
            Name = "Oto, Bahçe, Yapı Merket",
            SubCategoryId = 0,
            Sort = 3,
            CreatedDate = DateTime.Now.AddMinutes(rnd.NextInt64() * 20),
        };

        Category c4 = new()
        {
            Id = 4,
            Name = "Bilgisayar ve Tablet",
            SubCategoryId = 1,
            Sort = 1,
            CreatedDate = DateTime.Now.AddMinutes(rnd.NextInt64() * 20),
        };

        Category c5 = new()
        {
            Id = 5,
            Name = "Beyaz Eşye",
            SubCategoryId = 1,
            Sort = 2,
            CreatedDate = DateTime.Now.AddMinutes(rnd.NextInt64() * 20),
        };

        builder.HasData(c1, c2, c3, c4, c5);
    }
}
