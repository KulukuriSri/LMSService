using System;
using System.Collections.Generic;

namespace ELMSDAL.Models
{
    public partial class Instructor
    {
        public int? InstructorId { get; set; }
        public string InstructorName { get; set; }
        public string Courses { get; set; }
    }
}
