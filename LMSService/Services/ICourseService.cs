using DALLayer.ModelDTO;
using DALLayer.Models;

namespace LMSService.Services
{
    public interface ICourseService
    {
        Task<ServiceResponse<List<CourseDto>>> GetAllCourses();
        Task<ServiceResponse<CourseDto>> GetCourseByID(int id);
        Task<ServiceResponse<CourseDto>> AddCourse(CourseDto coursedetails);
        Task<ServiceResponse<CourseDto>> UpdateCourse(CourseDto coursedetails);

    }
}
