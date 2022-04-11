using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PackManagementSystem.DTOs;
using PackManagementSystem.DTOs.DriverDto;
using PackManagementSystem.Entities;
using PackManagementSystem.Interfaces.Repositories;
using PackManagementSystem.Interfaces.Services;

namespace PackManagementSystem.Implementations.Services
{
    public class DriverService:IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }
        public DriverResponseModel CreateDriver(DriverRequestModel driver)
        {
            //string divId = $"Div/{Guid.NewGuid().ToString().Substring(0, 3)}";
            var driv = new Driver()
            {
                Firstname = driver.Firstname,
                Lastname = driver.Surname,
                Address = driver.Address,
                Email = driver.Email,
                Dob = driver.Dob,
                ParkId = driver.ParkId,
                PhoneNumber = driver.PhoneNumber,
                DriverId = driver.DivId
            };
            var drive = _driverRepository.CreateDriver(driv);
            if (drive != null)
            {
                return new DriverResponseModel() {Status = true, Message = "Created Successfully"};
            }

            return new DriverResponseModel()
            {
                Status   = false,
                Message = "Failed"
            };
        }

        public DriversResponseModel GetAllDrivers()
        {
            var allDriver = _driverRepository.GetAllDrivers().Select(driver => new DriverDto
            {
                Firstname = driver.Firstname,
                Surname = driver.Lastname,
                Address = driver.Address,
                Email = driver.Email,
                Dob = driver.Dob,
                ParkId = driver.ParkId,
                PhoneNumber = driver.PhoneNumber,
                DivId = driver.DriverId,
                Id = driver.Id,
            }).ToList();
            return new DriversResponseModel() {Data = allDriver};
        }

        public bool DeleteDriver(int id)
        {
            var div = _driverRepository.GetDriver(id);
            if (div == null)
            {
                return false;
            }

            _driverRepository.DeleteDriver(div);
            return true;
        }

        public DriverResponseModel UpdateDriver(DriverRequestModel driver, int id)
        {
            var div = _driverRepository.GetDriver(id);
            if (div == null)
            {
                return new DriverResponseModel(){Message = "Failed to update"};
            }

            div.Email = driver.Email;
            div.Address = driver.Address;
            div.Firstname = driver.Firstname;
            div.Lastname = driver.Surname;
            div.PhoneNumber = driver.PhoneNumber;
            //div.ParkId = driver.ParkId;
            _driverRepository.UpdateDriver(div);
            return new DriverResponseModel() {Message = "Updated Successfullly"};
        }

        public DriverResponseModel GetDriver(int id)
        {
            var driver = _driverRepository.GetDriver(id);
            if (driver == null)
            {
                return new DriverResponseModel() {Message = "Failed"};
            }

            return new DriverResponseModel()
            {
                Data =new DriverDto()
                {
                    
                    Firstname = driver.Firstname,
                    Surname = driver.Lastname,
                    Address = driver.Address,
                    Email = driver.Email,
                    Dob = driver.Dob,
                    ParkId = driver.ParkId,
                    PhoneNumber = driver.PhoneNumber,
                    DivId = driver.DriverId,
                    Id = driver.Id
                }
            };

        }

        public IList<Motor> GetDriverByCar(int id)
        {
            var drive = _driverRepository.GetDriverByCar(id);
            return drive;
        }

        public DriverResponseModel DriverLogin(DriverRequestModel email, DriverRequestModel divId)
        {
            var div = new Driver() {Email = email.Email, DriverId = divId.DivId};
            var login = _driverRepository.Login(div.Email, div.DriverId);
            if (login == null)
            {
                return new DriverResponseModel() { Status = false, Message = "Invalid username or Password"};
            }

            return new DriverResponseModel()
            {
                Status = true, Data = new DriverDto(){Firstname = $"{login.Firstname+" "+ login.Firstname}", DivId = login.DriverId,
                    Id = login.Id, Email = login.Email}
            };
        }
    }
}