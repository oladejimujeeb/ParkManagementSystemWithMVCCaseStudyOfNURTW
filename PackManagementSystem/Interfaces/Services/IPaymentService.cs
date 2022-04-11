using System;
using System.Collections.Generic;
using PackManagementSystem.DTOs.PaymentDto;
using PackManagementSystem.Entities;

namespace PackManagementSystem.Interfaces.Services
{
    public interface IPaymentService
    {
        PaymentResponseModel MakePayment(PaymentRequestModel payment, int id);
        PaymentResponseModel GetPayment(int id);
        PaymentsResponseModel SearchPayment(DateTime date);
        PaymentsResponseModel SearchPaymentByDriver(string divId);
        PaymentsResponseModel SearchPaymentByPhoneNo(string phoneNo);
    }
}