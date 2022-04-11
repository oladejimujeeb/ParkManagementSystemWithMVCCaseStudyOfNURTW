using System;

namespace PackManagementSystem.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime ExpiryDate{ get; set; }
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }
        public int PaymentPeriod { get; set; }
        public int MotorId { get; set; }
        public  Motor Motor { get; set; }
    }
}