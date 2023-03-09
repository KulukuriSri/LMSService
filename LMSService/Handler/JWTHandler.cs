using DALLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using LMSService.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DALLayer;

namespace LMSService.Handler
{
    public class JWTHandler
    {
        private IConfiguration _config;
        private ApplicaitonDbContext db;

        public JWTHandler(IConfiguration config,ApplicaitonDbContext _db)
        {
            _config = config;
            db = _db;
        }

        public async Task<string> GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var signCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims: new List<Claim>(), // claims (are used to filter the data)
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserViewModel> AuthenticateUser(User login)
        {
            UserViewModel user = null;

            var userDetails = db.Users.Where(a=>a.UserName==login.UserName&&a.Password==login.Password).FirstOrDefault();
            //await foreach (var x in userDetails)
            //{
                if (userDetails!=null)
                {
                    return new UserViewModel {Id=userDetails.UserId, UserName = login.UserName, RoleId = userDetails.RoleId, Success=true };
                }
                else
                {
                  return new UserViewModel { UserName = login.UserName, RoleId = 0, Success = false };
                }
            //}            
        }
    }
}
