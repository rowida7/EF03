using System;
using System.Collections.Generic;
using System.Text;

namespace EF_03.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateOnly DOB { get; set; }

    }
}
