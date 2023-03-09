using DALLayer.Models;
using DALLayer.ModelDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using LMSService.Handler;
using LMSService.Models;
using LMSService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DALLayer;

namespace LMSService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserservice userService;
        private IConfiguration _config;
        private ApplicaitonDbContext db;

        public AuthController(IConfiguration config,ApplicaitonDbContext _db)
        {
            _config = config;
            userService = new UserService(config);
            db = _db;
        }
       
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Signin([FromBody] User login)
        {
            IActionResult response = Unauthorized();

            try
            {
                JWTHandler jWTHandler = new JWTHandler(_config, db);

                var user = await jWTHandler.AuthenticateUser(login);

                if (user.Success == true)
                {
                    user.Token = await jWTHandler.GenerateJSONWebToken();
                    response = Ok(user);
                }
                else
                {
                    response = Ok(user);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            

            return response;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<int> SignUp([FromBody] UserDto login)
        {
            int userID =await userService.signUp(login);

            return userID;
        }
    }
}
