using System.Collections.Generic;
using PackManagementSystem.DTOs.MotorDto;
using PackManagementSystem.Entities;

namespace PackManagementSystem.Interfaces.Repositories
{
    public interface IMotorRepository
    {
        Motor CreateMotor(Motor motor);
        IList<Motor> SearchMotorByDrv(int driverId);
        Motor SearchMotorByPark(int parkId);
        Motor UpdateMotor(Motor motor);
    }
}