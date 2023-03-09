
using DALLayer.ModelDTO;
using DALLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALLayer.Services
{
    public interface IUserRepository
    {
       public Task<int> signUp(UserDto user);

    }
}
