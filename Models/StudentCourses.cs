using EF_03.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF_03.Models
{
    internal class StudentCourses
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        [Range(0,100)]
        public decimal ProgressPercentage { get; set; }
        public Status Status { get; set; }  
        public DateOnly EnrollmentDate { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; } 
    }
}
