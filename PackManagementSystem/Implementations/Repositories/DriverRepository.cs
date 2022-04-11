using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PackManagementSystem.Context;
using PackManagementSystem.DTOs.DriverDto;
using PackManagementSystem.Entities;
using PackManagementSystem.Interfaces.Repositories;

namespace PackManagementSystem.Implementations.Repositories
{
    public class DriverRepository:IDriverRepository
    {
        private readonly ApplicationContext _context;

        public DriverRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Driver CreateDriver(Driver driver)
        {
           _context.Drivers.Add(driver);
           _context.SaveChanges();
           return driver;
        }

        public IList<Driver> GetAllDrivers()
        {
            var div = _context.Drivers.ToList();
            return div;
        }

        public bool DeleteDriver(Driver driver)
        {
            _context.Drivers.Remove(driver);
            _context.SaveChanges();
            return true;
        }

        public Driver UpdateDriver(Driver driver)
        {
            _context.Drivers.Update(driver);
            _context.SaveChanges();
            return driver;
        }

        public Driver GetDriver(int id)
        {
            var div = _context.Drivers.Find(id);
            return div;
        }

        public IList<Motor> GetDriverByCar(int divId)
        { 
            var divCar = _context.Motors.Include(x=>x.Park).Where(x=>x.DriverId==divId).ToList();
            return divCar;
        }

        public Driver Login(string email, string divId)
        {
            var loginDetails =
                _context.Drivers.FirstOrDefault(driver => driver.Email == email && driver.DriverId == divId);
            return loginDetails;
        }
    }
}