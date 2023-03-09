using DALLayer.ModelDTO;
using DALLayer.Models;
using LMSService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSService.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentEnrollController : ControllerBase
    {
        private readonly IStudentEnrollService _studentService;

        public StudentEnrollController(IStudentEnrollService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<ServiceResponse<StudentDto>> StudentEnroll(StudentDto student)
        {
            var objres = new ServiceResponse<StudentDto>();
            try
            {
                objres= await _studentService.StudentEnroll(student);

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
