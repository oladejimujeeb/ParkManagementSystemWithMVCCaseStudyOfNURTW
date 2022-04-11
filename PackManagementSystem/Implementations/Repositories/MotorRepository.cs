using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PackManagementSystem.Context;
using PackManagementSystem.DTOs.MotorDto;
using PackManagementSystem.Entities;
using PackManagementSystem.Interfaces.Repositories;

namespace PackManagementSystem.Implementations.Repositories
{
    public class MotorRepository:IMotorRepository
    {
        private readonly ApplicationContext _context;

        public MotorRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Motor CreateMotor(Motor motor)
        {
            _context.Motors.Add(motor);
            _context.SaveChanges();
            return motor;
        }

        public IList<Motor> SearchMotorByDrv(int driverId)
        {
            var divMotor = _context.Motors.Include(x => x.Park).Where(x => x.Id == driverId).ToList();
            return divMotor;
        }
        
        public Motor SearchMotorByPark(int motorId)
        {
            var motorPark = _context.Motors.Where(x=>x.Id==motorId).Include(x => x.Park).SingleOrDefault()
                ;
            return motorPark;
        }

        public Motor UpdateMotor(Motor motor)
        {
            _context.Motors.Update(motor);
            _context.SaveChanges();
            return motor;
        }
    }
}