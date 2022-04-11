using System.Collections.Generic;
using PackManagementSystem.DTOs.DriverDto;
using PackManagementSystem.Entities;

namespace PackManagementSystem.Interfaces.Repositories
{
    public interface IDriverRepository
    {
        Driver CreateDriver(Driver driver);
        IList<Driver> GetAllDrivers();
        bool DeleteDriver(Driver driver);
        Driver UpdateDriver(Driver driver);
        Driver GetDriver(int id);
        IList<Motor> GetDriverByCar(int divId);
        Driver Login(string email, string divId);
    }
}