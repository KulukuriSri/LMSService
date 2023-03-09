using System;
using System.Collections.Generic;

namespace DALLayer.Models
{
    public partial class Instructor
    {
        public int? InstructorId { get; set; }
        public string InstructorName { get; set; }
        public string Courses { get; set; }
    }
}
