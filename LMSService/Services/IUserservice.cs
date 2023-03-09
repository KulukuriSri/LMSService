using DALLayer.ModelDTO;
using DALLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSService.Services
{
    interface IUserservice
    {
       Task<int> signUp(UserDto user);
    }
}
