using DALLayer.ModelDTO;
using DALLayer.Models;
using DALLayer.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSService.Services
{
    public class UserService :IUserservice
    {
        private IUserRepository userRepository;

        public UserService(IConfiguration config)
        {
        }
        public async Task<int> signUp(UserDto user)
        {
            return await userRepository.signUp(user);
        }
    }

}
