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
    public class StudentEnrollService : IStudentEnrollService
    {
        private IStudentRepository _studentRepository;

        public StudentEnrollService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<ServiceResponse<StudentDto>> StudentEnroll(StudentDto student)
        {
            return await _studentRepository.StudentEnroll(student);
        }

    }
}
