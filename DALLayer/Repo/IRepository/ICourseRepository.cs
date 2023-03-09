using DALLayer.ModelDTO;
using DALLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALLayer.Services
{
    public interface ICourseRepository
    {
        Task<ServiceResponse<CourseDto>> AddCourse(CourseDto coursedetails);
        Task<ServiceResponse<CourseDto>> Updatecourse(CourseDto coursedetails);
        Task<ServiceResponse<List<CourseDto>>> GetAllCourses();
        Task<ServiceResponse<CourseDto>> GetCourseByID(int Id);
    }
}
