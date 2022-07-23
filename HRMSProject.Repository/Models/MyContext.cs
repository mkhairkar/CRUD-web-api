using HRMSProject.Repository.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.Repository.Models
{
    public class MyContext : NextTurnDBContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<NextTurnDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DeptEmp> DeptEmps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DeptEmp>(x => x.HasNoKey());
        }
    }
}
