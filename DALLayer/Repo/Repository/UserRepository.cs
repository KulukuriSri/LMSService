using DALLayer.ModelDTO;
using DALLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALLayer.Services
{
    public class UserRepository : IUserRepository
    {
        private IConfiguration _config;
        private ApplicaitonDbContext db;
        private LogDataDto objmethd;
        public UserRepository(IConfiguration config,ApplicaitonDbContext _db, LogDataDto _objmethd)
        {
            _config = config;
            db = _db;
            objmethd = _objmethd;
        }
        public async Task<int> signUp(UserDto user)
        {
            objmethd.LogDetails("BeforeSaving", "");
            Users obj = new Users();
            try
            {                
                obj.UserName = user.UserName;
                obj.Password = user.Password;
                obj.RoleId = user.RoleId;
                if (obj != null)
                    db.Users.Add(obj);
                db.SaveChanges();               
            }
            catch(Exception ex)
            {
                objmethd.LogDetails("CatchBlock",ex.Message);
            }
            objmethd.LogDetails("AfterSaving", "");
            return obj.UserId;
        }

    }
    
}
