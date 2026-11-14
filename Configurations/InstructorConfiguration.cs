using Microsoft.EntityFrameworkCore;
using EF_03.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_03.Configurations
{
    internal class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.Property<DateOnly>("JoiningDate")
                .HasDefaultValueSql("GetDate()");
        }
    }
}
