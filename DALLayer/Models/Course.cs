using System;
using System.Collections.Generic;

namespace DALLayer.Models
{
    public partial class Course
    {
        public Course()
        {
            Student = new HashSet<Student>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Tag { get; set; }
        public string Category { get; set; }
        public string SubCatergory { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
