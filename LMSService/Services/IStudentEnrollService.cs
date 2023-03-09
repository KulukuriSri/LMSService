using DALLayer.ModelDTO;
using DALLayer.Models;

namespace LMSService.Services
{
    public interface IStudentEnrollService
    {
        Task<ServiceResponse<StudentDto>> StudentEnroll(StudentDto student);
    }
}
