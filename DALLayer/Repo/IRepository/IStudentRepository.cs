using DALLayer.ModelDTO;
using DALLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALLayer.Services
{
    public interface IStudentRepository
    {
        Task<ServiceResponse<StudentDto>> StudentEnroll(StudentDto student);
    }
}
