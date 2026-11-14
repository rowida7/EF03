using System;
using System.Collections.Generic;
using System.Text;

namespace EF_03.Models
{
    internal class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public ICollection<Course> Courses { get; set;} = new HashSet<Course>();

        public int? SuperCategoryId {  get; set; }
        public Category? SuperCategory {  get; set; }
        
    }
}
