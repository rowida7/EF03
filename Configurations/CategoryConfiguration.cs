using EF_03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_03.Configurations
{
    internal class CategoryConfiguration: IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasOne(c => c.SuperCategory)
                 .WithMany().HasForeignKey(c => c.SuperCategoryId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
