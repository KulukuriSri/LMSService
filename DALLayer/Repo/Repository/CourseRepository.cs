using DALLayer.ModelDTO;
using DALLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALLayer.Services
{
   public class CourseRepository :ICourseRepository
    {

        private ApplicaitonDbContext db;

        public CourseRepository(ApplicaitonDbContext _db)
        {
            db = _db;
        }

       public async Task<ServiceResponse<CourseDto>> AddCourse(CourseDto course) 
        {
            var objres = new ServiceResponse<CourseDto>();
            LogDetails("BeforeCourseSaving", "");
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
                LogDetails("AfterCourseSaving", "");
                return objres;
            }
            catch (Exception ex)
            {
                objres.Message = ex.Message;
                LogDetails("CatchBlock",ex.Message);
                objres.Success = false;
                return objres;
            }                     
        }

        public async Task<ServiceResponse<CourseDto>> Updatecourse(CourseDto course)
        {
            var objres = new ServiceResponse<CourseDto>();
            LogDetails("BeforeCourseupdating", "");
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
                LogDetails("AfterCourseupdating", "");
                return objres;
            }
            catch (Exception ex)
            {
                objres.Message = ex.Message;
                LogDetails("CatchBlock",ex.Message);
                objres.Success = false;
                return objres;
            }
                      
        }
        public async Task<ServiceResponse<List<CourseDto>>> GetAllCourses()
        {
            var objres = new ServiceResponse<List<CourseDto>>();
            LogDetails("BeforeCourseList", "");
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
                LogDetails("AfterCourseList", "");
                return objres;
            }

            catch (Exception ex)
            {
                objres.Message = ex.Message;
                LogDetails("CatchBlock",ex.Message);
                objres.Success = false;
                return objres;
            }         
        }

        public async Task<ServiceResponse<CourseDto>> GetCourseByID(int Id)
        {
            var objres = new ServiceResponse<CourseDto>();
            LogDetails("BeforeCourse", "");
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
               LogDetails("AfterCourse", "");
                return objres;
            }

            catch (Exception ex)
            {
                objres.Message = ex.Message;
               LogDetails("CatchBlock", ex.Message);
                objres.Success = false;
                return objres;
            }
        }

        public void LogDetails(string Logmessage, string exceptionmessage)
        {
            Logs obj = new Logs();
            obj.Logmessage = Logmessage;
            obj.Execptionmessage = exceptionmessage != "" ? exceptionmessage : null;
            obj.CreatedDate = DateTime.Now;
            db.Logs.Add(obj);
            db.SaveChanges();
        }

    }
}
