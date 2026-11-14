using System;
using System.Collections.Generic;
using System.Text;

namespace EF_03.Models
{
    internal class Instructor
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Bio { get; set; } = null!;
        public DateOnly JoiningDate { get; set; }

        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();

    }
}
