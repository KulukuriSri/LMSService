
using ELMSDAL.ModelDTO;
using ELMSDAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELMSDAL.Services
{
    public interface IUserRepository
    {
       public Task<int> signUp(UserDto user);
    }
}
