using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSService.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public int? RoleId { get; set; }
        public bool Success { get; set; }
    }
}
