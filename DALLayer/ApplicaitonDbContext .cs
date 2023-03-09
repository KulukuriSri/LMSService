using DALLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DALLayer
{
    public class ApplicaitonDbContext : DbContext    {
        

        public ApplicaitonDbContext(DbContextOptions<ApplicaitonDbContext> options) : base(options)
         {

         }

      //  protected override void OnModelCreating(ModelBuilder builder) 
      //  {
      //     // builder.Entity<Roles>().Property(p => p.RoleId).ValueGeneratedOnAdd(); base.OnModelCreating(builder);

      //      builder
      //.Entity<Roles>(
      //    eb =>
      //    {
      //        eb.HasNoKey();
      //        eb.Property(v => v.RoleId).HasColumnName("RoleId");
      //        eb.Ignore(v => v.RoleId);
      //        eb.Ignore(v => v.RoleName);
      //    });
      //  }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Users> Users { get; set; }

    }
}
