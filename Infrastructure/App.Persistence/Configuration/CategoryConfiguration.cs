using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            Category ct1 = new Category() {

                Id = 1,
                Name = "elektrik",
                Priorty = 1,
                ParentId = 0,
                IsDeleted = false,
                CreatedDate=DateTime.Now
                
                };
            Category ct2 = new Category()
            {

                Id = 2,
                Name = "moda",
                Priorty = 2,
                ParentId = 0,
                IsDeleted = false,
                CreatedDate = DateTime.Now

            };
            Category parent1 = new Category()
            {

                Id = 3,
                Name = "bilgisayar",
                Priorty = 1,
                ParentId = 1,
                IsDeleted = false,
                CreatedDate = DateTime.Now

            };
            Category parent2 = new Category()
            {

                Id = 4,
                Name = "kadin",
                Priorty = 1,
                ParentId = 2,
                IsDeleted = false,
                CreatedDate = DateTime.Now

            };
            builder.HasData(ct1, ct2, parent1, parent2);

        }
    }
}
