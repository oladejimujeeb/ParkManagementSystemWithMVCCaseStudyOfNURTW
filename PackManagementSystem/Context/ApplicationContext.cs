using Microsoft.EntityFrameworkCore;
using PackManagementSystem.Entities;

namespace PackManagementSystem.Context
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Driver>Drivers{get; set;}
        public DbSet<Motor> Motors { get; set;}
        public DbSet<Park> Parks { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Staff>Staffs { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

    }
}