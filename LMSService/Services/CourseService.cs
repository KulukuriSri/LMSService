using DALLayer.ModelDTO;
using DALLayer.Models;
using DALLayer.Services;
using LMSService.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSService.Services
{
    public class CourseService :ICourseService
    {
       private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<ServiceResponse<List<CourseDto>>> GetAllCourses()
        {

            return await _courseRepository.GetAllCourses();
        }

        public async Task<ServiceResponse<CourseDto>> GetCourseByID(int Id)
        {
            return await _courseRepository.GetCourseByID(Id);
        }

        public async Task<ServiceResponse<CourseDto>> AddCourse(CourseDto course)
        {
            return await _courseRepository.AddCourse(course);
        }

        public async Task<ServiceResponse<CourseDto>> UpdateCourse(CourseDto coursedetails)
        {
            return await _courseRepository.Updatecourse(coursedetails);
        }


    }
}
