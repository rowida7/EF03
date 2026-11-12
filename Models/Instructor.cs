using System;
using System.Collections.Generic;
using System.Text;

namespace EF_03.Models
{
    internal class Instructor
    {
        public int Id { get; set; }
        public string FillName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public DateOnly JoiningDate { get; set; }

    }
}
