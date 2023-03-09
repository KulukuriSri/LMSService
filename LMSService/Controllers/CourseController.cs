using DALLayer.ModelDTO;
using DALLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMSService.Services;
using DALLayer.Services;

namespace LMSService.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
       private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ServiceResponse<List<CourseDto>>> GetAllCourses()
        {
            var objres = new ServiceResponse<List<CourseDto>>();
            try
            {
                objres = await _courseService.GetAllCourses();
            }
            catch (Exception ex)
            {
                objres.Message = ex.Message;
                objres.Success = false;
            }
            return objres;
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<CourseDto>> GetCourseByID(int id)
        {
            var objres = new ServiceResponse<CourseDto>();
            try
            {
                objres = await _courseService.GetCourseByID(id);
            }
            catch (Exception ex)
            {
                objres.Message = ex.Message;
                objres.Success = false;
            }
            return objres;
        }

        [HttpPost]
        public async Task<ServiceResponse<CourseDto>> AddCourse(CourseDto coursedetails)
        {
            var objres = new ServiceResponse<CourseDto>();
            try
            {
                objres= await _courseService.AddCourse(coursedetails);
            }
            catch (Exception ex)
            {
                objres.Message = ex.Message;
                objres.Success = false;
            }
            return objres;
        }

        
        [HttpPut]
        public async Task<ServiceResponse<CourseDto>> UpdateCourse(CourseDto coursedetails)
        {
            var objres = new ServiceResponse<CourseDto>();
            try
            {
                objres = await _courseService.UpdateCourse(coursedetails);
            }
            catch (Exception ex)
            {
                objres.Message = ex.Message;
                objres.Success = false;
            }
            return objres;
        }


    }
}