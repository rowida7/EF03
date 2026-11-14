using System;
using System.Collections.Generic;
using System.Text;

namespace EF_03.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateOnly DOB { get; set; }

        public ICollection<StudentCourses> StudentCourses { get; set; } = new HashSet<StudentCourses>();
    }
}
