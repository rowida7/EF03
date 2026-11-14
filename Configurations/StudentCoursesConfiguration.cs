using EF_03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_03.Configurations
{
    internal class StudentCoursesConfiguration : IEntityTypeConfiguration<StudentCourses>
    {
        public void Configure(EntityTypeBuilder<StudentCourses> builder)
        {
            builder.HasOne(sc => sc.Course)
                .WithMany(c=> c.StudentCourses).HasForeignKey(sc => sc.CourseId);

            builder.HasOne(sc => sc.Student)
               .WithMany(s=> s.StudentCourses).HasForeignKey(sc => sc.StudentId);

            builder.HasKey(sc=> new {sc.StudentId, sc.CourseId});


        }
    }
}
