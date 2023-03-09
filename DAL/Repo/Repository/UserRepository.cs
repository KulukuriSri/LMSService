using ELMSDAL.ModelDTO;
using ELMSDAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELMSDAL.Services
{
    public class UserRepository : IUserRepository
    {
        private IConfiguration _config;
        ELMSContext context = new ELMSContext();
        LogDataDto objmethd = new LogDataDto();
        public UserRepository(IConfiguration config)
        {
            _config = config;
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
                    context.Users.Add(obj);
                context.SaveChanges();               
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
