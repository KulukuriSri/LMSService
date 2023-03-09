using System;
using System.Collections.Generic;

namespace ELMSDAL.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }

        public virtual Roles Role { get; set; }
    }
}
