using System.Collections.Generic;
using PackManagementSystem.Entities;

namespace PackManagementSystem.DTOs.MotorDto
{
    public class MotorDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string CarType{ get; set; }
        public int NoOfSeater { get; set; }
        public string CarReg { get; set; }
        public string DriverName { get; set; }
        public string ParkName{ get; set; }
        public string DriverReg { get; set; }
        public int ParkId { get; set; }
        public int DriverId { get; set; }
        //public Driver Driver { get; set; }
        //public virtual IList<Payment> Payments { get; set; } = new List<Payment>();
    }

    public class MotorRequestModel
    {
        public string CarName { get; set; }
        public string CarType{ get; set; }
        public int NoOfSeater { get; set; }
        public string CarReg { get; set; }
        //public string DriverName { get; set; }
        //public string ParkName{ get; set; }
        //public string DriverReg { get; set; }
        public int ParkId { get; set; }
        public int DriverId { get; set; }
        //public Driver Driver { get; set; }
        //public virtual IList<Payment> Payments { get; set; } = new List<Payment>();
    }

    public class MotorResponseModel:BaseResponseModel
    {
        public MotorDto Data { get; set; }
    }

    public class MotorsResponseModel:BaseResponseModel
    {
        public IList<MotorDto> Data { get; set; } = new List<MotorDto>();
    }
}