using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DALLayer.Models
{
    public partial class Users
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }

        public virtual Roles Role { get; set; }
    }
}
