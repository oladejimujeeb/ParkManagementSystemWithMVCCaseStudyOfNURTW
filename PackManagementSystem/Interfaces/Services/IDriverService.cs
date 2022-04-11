using System.Collections.Generic;
using PackManagementSystem.DTOs;
using PackManagementSystem.DTOs.DriverDto;
using PackManagementSystem.Entities;

namespace PackManagementSystem.Interfaces.Services
{
    public interface IDriverService
    {
        DriverResponseModel CreateDriver(DriverRequestModel driver);
        DriversResponseModel GetAllDrivers();
        bool DeleteDriver(int id);
        DriverResponseModel UpdateDriver(DriverRequestModel driver, int id);
        DriverResponseModel GetDriver(int id);
        IList<Motor> GetDriverByCar(int id);
        DriverResponseModel DriverLogin(DriverRequestModel email, DriverRequestModel divId);
        
    }
}