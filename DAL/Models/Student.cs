using System;
using System.Collections.Generic;

namespace ELMSDAL.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public string StudentName { get; set; }
        public int? CourseEnrollement { get; set; }

        public virtual Course CourseEnrollementNavigation { get; set; }
    }
}
