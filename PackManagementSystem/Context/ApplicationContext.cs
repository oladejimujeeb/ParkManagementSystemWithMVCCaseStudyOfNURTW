using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(
            new Admin
            {
                Id = 1,
                Email = "oladejimujeeb@yahoo.com",
                Firstname = "Mujib",
                Lastname = "Oladeji",
                PhoneNumber = "08136794915",
                Password = "mujib",
            }
            );
        }

        /*public override DatabaseFacade Database => base.Database;
        public override ChangeTracker ChangeTracker => base.ChangeTracker;
        public override IModel Model => base.Model;
        public override DbContextId ContextId => base.ContextId;*/

    }
}