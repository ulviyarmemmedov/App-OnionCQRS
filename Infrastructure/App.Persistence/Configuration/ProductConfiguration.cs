using App.Domain.Entities;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Faker faker = new("tr");

            Product product1 = new Product()
            {
                Id = 1,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                CreatedDate = DateTime.Now,
                BrandId = 1,
                Price = faker.Finance.Amount(10, 1000),
                Discount = faker.Random.Decimal(0, 10),
                IsDeleted=false

            };
            Product product2 = new Product()
            {
                Id = 1,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                CreatedDate = DateTime.Now,
                BrandId = 3,
                Price = faker.Finance.Amount(10, 1000),
                Discount = faker.Random.Decimal(0, 10),
                IsDeleted = false

            };
            builder.HasData(product1, product2);
        }
    }
}
