using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PackManagementSystem.Context;
using PackManagementSystem.DTOs.PaymentDto;
using PackManagementSystem.Entities;
using PackManagementSystem.Interfaces.Repositories;

namespace PackManagementSystem.Implementations.Repositories
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly ApplicationContext _context;

        public PaymentRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Payment MakePayment(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
            return payment;
        }

        public Payment GetPayment(int id)
        {
           var payment= _context.Payments.FirstOrDefault(x => x.MotorId== id);
           return payment;
        }

        public IList<PaymentDto> SearchPayment(DateTime date)
        {
            var confirmPay=_context.Payments.Where(x=>x.PaymentDate==date).Include(x=>x.Motor)
                .Select(pay=> new PaymentDto
                {
                    PaymentDate = pay.PaymentDate,
                    Amount = pay.Amount,
                    Id = pay.Id,
                    PaymentPeriod= pay.PaymentPeriod,
                    CarName = pay.Motor.Carname,
                    ExpiryDate = pay.ExpiryDate,
                    MotorId = pay.Motor.CarReg,
                    ParkName = pay.Motor.Park.Name,
                    DivId = pay.Motor.Driver.DriverId,
                }).ToList();
            return confirmPay;
        }

        public IList<PaymentDto> SearchPaymentByDriver(string divId)
        { 
            var paymentHistory = _context.Payments.Include(x=>x.Motor)
                .Where(x=>x.Motor.Driver.DriverId==divId).Select(pay => new PaymentDto
                {
                    PaymentDate = pay.PaymentDate,
                    Amount = pay.Amount,
                    Id = pay.Id,
                    PaymentPeriod= pay.PaymentPeriod,
                    CarName = pay.Motor.Carname,
                    ExpiryDate = pay.ExpiryDate,
                    MotorId = pay.Motor.CarReg,
                    ParkName = pay.Motor.Park.Name,
                    DivId = pay.Motor.Driver.DriverId,
                }).ToList();
            return paymentHistory;
        }

        public IList<PaymentDto> SearchPaymentByPhoneNo(string email)
        {
            var paymentHistory = _context.Payments.Include(x=>x.Motor)
                .Where(x=>x.Motor.Driver.Email==email).Select(pay => new PaymentDto
                {
                    PaymentDate = pay.PaymentDate,
                    Amount = pay.Amount,
                    Id = pay.Id,
                    PaymentPeriod= pay.PaymentPeriod,
                    CarName = pay.Motor.Carname,
                    ExpiryDate = pay.ExpiryDate,
                    MotorId = pay.Motor.CarReg,
                    ParkName = pay.Motor.Park.Name,
                    DivId = pay.Motor.Driver.DriverId,
                }).ToList();
            return paymentHistory;
        }
    }
}