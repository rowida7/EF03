using EF_03.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_03.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Level Level { get; set; }
        public DateOnly PuplishDate {  get; set; }
        public bool IsPublished = false;
    }
}
