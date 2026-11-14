using EF_03.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF_03.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Level Level { get; set; }
        public DateOnly PuplishDate {  get; set; }
        public bool IsPublished = false;

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; } = null!;


        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public ICollection<StudentCourses> StudentCourses { get; set; } = new HashSet<StudentCourses>();

    }
}
