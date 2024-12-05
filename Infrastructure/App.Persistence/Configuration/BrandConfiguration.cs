using App.Domain.Entities;
using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence.Configuration
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Brand> builder)
        {
            Faker faker = new("tr");
           Brand brand1= new Brand()
           {
               Id=1,
               CreatedDate = DateTime.Now,
               IsDeleted=false,
               Name=faker.Commerce.Department()
           };

           Brand brand2 = new Brand()
            {
                Id = 2,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                Name = faker.Commerce.Department()
            };

           Brand brand3 = new Brand()
            {
                Id = 3,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                Name = faker.Commerce.Department()
            };
            builder.HasData(brand1, brand2, brand3);

        }
    }
}
