using ELMSDAL.ModelDTO;
using ELMSDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELMSDAL.Services
{
   public class CourseRepository :ICourseRepository
    {
        ELMSContext db = new ELMSContext();
        LogDataDto objmethd = new LogDataDto();
       public async Task<ServiceResponse<CourseDto>> AddCourse(CourseDto course) 
        {
            var objres = new ServiceResponse<CourseDto>();
            objmethd.LogDetails("BeforeCourseSaving", "");
            try
            {
                Course obj = new Course();
                obj.CourseName = course.CourseName;
                obj.Tag = course.Tag;
                obj.Category = course.Category;
                obj.SubCatergory = course.SubCatergory;
                db.Course.Add(obj);
                db.SaveChanges();
                course.CourseId = obj.CourseId;
                objres.Data = course;
                objres.Success = true;
                objres.Message ="Course Added Successfully";
                objmethd.LogDetails("AfterCourseSaving", "");
                return objres;
            }
            catch (Exception ex)
            {
                objres.Message = ex.Message;
                objmethd.LogDetails("CatchBlock",ex.Message);
                objres.Success = false;
                return objres;
            }                     
        }

        public async Task<ServiceResponse<CourseDto>> Updatecourse(CourseDto course)
        {
            var objres = new ServiceResponse<CourseDto>();
            objmethd.LogDetails("BeforeCourseupdating", "");
            try
            {
                Course courseDetails = db.Course.FirstOrDefault(x => x.CourseId == course.CourseId);
                courseDetails.CourseName = course.CourseName;
                courseDetails.Tag = course.Tag;
                courseDetails.SubCatergory = course.SubCatergory;                              
                db.SaveChanges();
                objres.Data = course;
                objres.Success = true;
                objres.Message = "Course Updated successfully";
                objmethd.LogDetails("AfterCourseupdating", "");
                return objres;
            }
            catch (Exception ex)
            {
                objres.Message = ex.Message;
                objmethd.LogDetails("CatchBlock",ex.Message);
                objres.Success = false;
                return objres;
            }
                      
        }
        public async Task<ServiceResponse<List<CourseDto>>> GetAllCourses()
        {
            var objres = new ServiceResponse<List<CourseDto>>();
            objmethd.LogDetails("BeforeCourseList", "");
            try
            {
                var Courselst = (from n in db.Course select new CourseDto {
                                  CourseId=n.CourseId,
                                  CourseName=n.CourseName,
                                  Tag=n.Tag.Trim(),
                                  SubCatergory=n.SubCatergory.Trim(),
                                  Category=n.Category.Trim()
                }).ToList();
                objres.Data= Courselst;
                objres.Success = true;
                objres.Message = Courselst.Count()>0?"List of Courses Available":"Courses Not Available";
                objmethd.LogDetails("AfterCourseList", "");
                return objres;
            }

            catch (Exception ex)
            {
                objres.Message = ex.Message;
                objmethd.LogDetails("CatchBlock",ex.Message);
                objres.Success = false;
                return objres;
            }         
        }

        public async Task<ServiceResponse<CourseDto>> GetCourseByID(int Id)
        {
            var objres = new ServiceResponse<CourseDto>();
            objmethd.LogDetails("BeforeCourse", "");
            try
            {
                var Courselst = (from n in db.Course
                                 where n.CourseId==Id
                                 select new CourseDto
                                 {
                                     CourseId = n.CourseId,
                                     CourseName = n.CourseName,
                                     Tag = n.Tag.Trim(),
                                     SubCatergory = n.SubCatergory.Trim(),
                                     Category = n.Category.Trim()
                                 }).FirstOrDefault();
                objres.Data = Courselst;
                objres.Success = true;
                objmethd.LogDetails("AfterCourse", "");
                return objres;
            }

            catch (Exception ex)
            {
                objres.Message = ex.Message;
                objmethd.LogDetails("CatchBlock", ex.Message);
                objres.Success = false;
                return objres;
            }
        }

    }
}
