using ELMSDAL.ModelDTO;
using ELMSDAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELMSDAL.Services
{
  public class StudentRepository:IStudentRepository
    {
        ELMSContext db=new ELMSContext();
        LogDataDto objmethd = new LogDataDto();
        public async Task<ServiceResponse<StudentDto>> StudentEnroll(StudentDto student)
        {
            var objres = new ServiceResponse<StudentDto>();
            objmethd.LogDetails("BeforeSaving", "");
            try
            {
                var enrollexist = db.Student.Where(a => a.StudentId == student.StudentId && a.StudentName == student.StudentName && a.CourseEnrollement == student.CourseEnrollement).FirstOrDefault();
                if(enrollexist!=null)
                { 
                  objres.Success = false;
                  objres.Message = "You already Enrolled";
                   return objres;
                }

                Student obj = new Student();
                if (student != null)
                {                    
                    obj.StudentId = student.StudentId;
                    obj.StudentName = student.StudentName;
                    obj.CourseEnrollement = student.CourseEnrollement;
                    db.Student.Add(obj);
                }
                db.SaveChanges();
                student.Id = obj.Id;
                objres.Success = true;
                objres.Message = "You Enrolled Successfully";
                objres.Data = student;
                objmethd.LogDetails("BeforeSaving", "");
                return objres;
            }

            catch (Exception ex)
            {
                objres.Message= ex.Message;
                objmethd.LogDetails("CatchBlock", ex.Message);
                objres.Success = false;
                return objres;
            }
            
        }
    }
}
