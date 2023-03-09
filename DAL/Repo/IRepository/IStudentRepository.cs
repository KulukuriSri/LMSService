using ELMSDAL.ModelDTO;
using ELMSDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELMSDAL.Services
{
    interface IStudentRepository
    {
        Task<ServiceResponse<StudentDto>> StudentEnroll(StudentDto student);
    }
}
