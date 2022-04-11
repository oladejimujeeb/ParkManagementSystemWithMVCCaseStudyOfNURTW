using System;
using System.Collections.Generic;
using System.Linq;
using PackManagementSystem.DTOs.PaymentDto;
using PackManagementSystem.Entities;
using PackManagementSystem.Interfaces.Repositories;
using PackManagementSystem.Interfaces.Services;

namespace PackManagementSystem.Implementations.Services
{
    public class PaymentService:IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMotorRepository _motorRepository;

        public PaymentService(IPaymentRepository paymentRepository, IMotorRepository motorRepository)
        {
            _paymentRepository = paymentRepository;
            _motorRepository = motorRepository;
        }
        
        public PaymentResponseModel MakePayment(PaymentRequestModel payment, int id)
        { 
            var getPark = _motorRepository.SearchMotorByPark(id);
            
            
            var pay = new Payment
            {
                Amount = getPark.Park.Price * getPark.NoOfSeater * payment.PaymentPeriod,
                PaymentDate = DateTime.Now.Date,
                ExpiryDate = DateTime.Today.Date.AddDays(payment.PaymentPeriod),
                MotorId =getPark.Id,
                PaymentPeriod = payment.PaymentPeriod
            };
            var makePayment = _paymentRepository.MakePayment(pay);
            return new PaymentResponseModel {Status = true, Data = new PaymentDto(){ExpiryDate = makePayment.ExpiryDate, Amount = makePayment.Amount}};
        }

        public PaymentResponseModel GetPayment(int id)
        {
            var getPaymentHistory = _paymentRepository.GetPayment(id);
            if (getPaymentHistory == null)
            {
                return new PaymentResponseModel() { Status = false};
            }

            return new PaymentResponseModel
            {
                Status = true,Data = new PaymentDto(){Amount = getPaymentHistory.Amount,ExpiryDate =getPaymentHistory.ExpiryDate,PaymentDate = getPaymentHistory.PaymentDate}
            };
        }

        public PaymentsResponseModel SearchPayment(DateTime date)
        {
            var getPayment = _paymentRepository.SearchPayment(date);
            if (getPayment == null)
            {
                return new PaymentsResponseModel() { Status = false, Message = "No Payment on this date"};
            }

            return new PaymentsResponseModel() { Data = getPayment, Status = true};
        }

        public PaymentsResponseModel SearchPaymentByDriver(string divId)
        {
            var payment = _paymentRepository.SearchPaymentByDriver(divId);
            if (payment == null)
            {
                return new PaymentsResponseModel { Status = false, Message = "No payment made so far"};
            }
            return new PaymentsResponseModel() {Data = payment, Status = true};
        }

        public PaymentsResponseModel SearchPaymentByPhoneNo(string email)
        {
            var payment = _paymentRepository.SearchPaymentByPhoneNo(email);
            if (payment == null)
            {
                return new PaymentsResponseModel { Status = false, Message = "No payment made so far"};
            }
            return new PaymentsResponseModel() {Data = payment, Status = true};
        }
    }
}