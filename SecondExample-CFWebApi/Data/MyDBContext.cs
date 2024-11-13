using Microsoft.EntityFrameworkCore;
using SecondExample_CFWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//3 packages from Nuget: EF Core, EF Core Sqlserver, EF Core Design...
namespace SecondExample_CFWebApi.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() :base() {  }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS; Database=ProductDB; Trusted_Connection=true");
        //}

        //Create a DBset for the table that U want to create...
        public DbSet<Product> Products { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}
