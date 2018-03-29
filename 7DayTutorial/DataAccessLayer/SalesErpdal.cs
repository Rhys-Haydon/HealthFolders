using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using _7DayTutorial.Models;

namespace _7DayTutorial.DataAccessLayer
{

    
    public class SalesErpdal : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("TblEmployee");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }


    }

    
}