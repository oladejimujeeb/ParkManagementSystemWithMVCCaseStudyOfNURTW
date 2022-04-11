using System;
using System.Collections.Generic;
using PackManagementSystem.DTOs.MotorDto;
using PackManagementSystem.Entities;
using PackManagementSystem.Interfaces.Repositories;
using PackManagementSystem.Interfaces.Services;

namespace PackManagementSystem.Implementations.Services
{
    public class MotorService:IMotorService
    {
        private readonly IMotorRepository _motorRepository;

        public MotorService(IMotorRepository motorRepository)
        {
            _motorRepository = motorRepository;
        }
        public MotorResponseModel CreateMotor(MotorRequestModel motor, int id)
        {
            string CarId = $"NURT/{Guid.NewGuid().ToString().Substring(0, 3)}";
            var vehicle = new Motor() {Carname = motor.CarName, CarReg = CarId, CarType = motor.CarType,ParkId =motor.ParkId, DriverId = id, NoOfSeater = motor.NoOfSeater};
            var addMotor = _motorRepository.CreateMotor(vehicle);
            return new MotorResponseModel() {Status = true, Message = "Motor Registered Successfully"};
        }

        public IList<Motor> SearchMotorByDrv(int driverId)
        {
            var motor = _motorRepository.SearchMotorByDrv(driverId);
            return motor;
        }

        public Motor UpdateMotor(MotorRequestModel motor)
        {
            var car = new Motor()
            {
                Carname = motor.CarName, CarReg = motor.CarReg, CarType = motor.CarType, NoOfSeater = motor.NoOfSeater,
                ParkId = motor.ParkId
            };
            var updateCar = _motorRepository.UpdateMotor(car);
            return updateCar;
        }

        public Motor SearchMotorByPark(int motorId)
        {
            var getPark = _motorRepository.SearchMotorByPark(motorId);
            return getPark;
        }
    }
}