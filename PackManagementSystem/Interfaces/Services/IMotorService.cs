using System.Collections.Generic;
using PackManagementSystem.DTOs.MotorDto;
using PackManagementSystem.Entities;

namespace PackManagementSystem.Interfaces.Services
{
    public interface IMotorService
    {
        MotorResponseModel CreateMotor(MotorRequestModel motor, int id);
        IList<Motor> SearchMotorByDrv(int driverId);
        Motor UpdateMotor(MotorRequestModel motor);
        Motor SearchMotorByPark(int parkId);
    }
}