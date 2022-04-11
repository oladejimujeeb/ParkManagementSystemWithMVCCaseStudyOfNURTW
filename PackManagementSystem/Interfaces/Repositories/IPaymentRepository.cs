using System;
using System.Collections.Generic;
using PackManagementSystem.DTOs.PaymentDto;
using PackManagementSystem.Entities;

namespace PackManagementSystem.Interfaces.Repositories
{
    public interface IPaymentRepository
    {
        Payment MakePayment(Payment payment);
        Payment GetPayment(int idd);
        IList<PaymentDto> SearchPayment(DateTime date);
        IList<PaymentDto> SearchPaymentByDriver(string divId);
        IList<PaymentDto> SearchPaymentByPhoneNo(string phoneNo);
    }
}