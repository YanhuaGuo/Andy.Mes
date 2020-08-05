using Andy.Mes.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andy.Mes.DbMigration
{
    public class MesDbContext : DbContext
    {
        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Device> Devices { get; set; }

        public DbSet<StaffDevice> StaffDevice { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=mes;Integrated Security=True");
        }
    }
}
