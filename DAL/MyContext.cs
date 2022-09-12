using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL
{
    public class MyContext : DbContext
    {
        public DbSet<Good> Goods { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<GoodOnWarehouse> GoodsOnWarehouses { get; set; }

        public MyContext(DbContextOptions<MyContext> contextOptions)
           : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GoodOnWarehouse>().HasKey(x => new { x.GoodId, x.WarehouseId });
        }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    var configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\ASP.NET Core API\")
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    var connectionString = configuration.GetConnectionString("DefaultConnection");
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

    }
}
