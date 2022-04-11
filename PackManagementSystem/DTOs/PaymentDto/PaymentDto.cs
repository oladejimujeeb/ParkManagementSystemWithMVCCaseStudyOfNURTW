using System;
using System.Collections.Generic;

namespace PackManagementSystem.DTOs.PaymentDto
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public string DivId { get; set; }
        public string ParkName { get; set; }
        public string CarName  { get; set; }  
        public DateTime ExpiryDate{ get; set; }
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }
        public int PaymentPeriod { get; set; }
        public string MotorId { get; set; }
        
    }

    public class PaymentRequestModel
    {
        /*public int Id { get; set; }
        public string DivId { get; set; }
        public string ParkName { get; set; }
        public string CarName  { get; set; }  
        public DateTime ExpiryDate{ get; set; }*/
        public DateTime PaymentDate { get; set; }
        //public double Amount { get; set; }
        public int PaymentPeriod { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }
    
    public class PaymentResponseModel:BaseResponseModel
    {
        public PaymentDto Data { get; set; } 
    }
    public class PaymentsResponseModel:BaseResponseModel
    {
        public IList<PaymentDto> Data { get; set; } = new List<PaymentDto>();
    }
}