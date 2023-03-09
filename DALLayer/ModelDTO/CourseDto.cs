using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALLayer.ModelDTO
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Tag { get; set; }
        public string Category { get; set; }
        public string SubCatergory { get; set; }
    }
}
