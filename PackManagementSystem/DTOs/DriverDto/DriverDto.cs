using System;
using System.Collections;
using System.Collections.Generic;
using PackManagementSystem.Entities;

namespace PackManagementSystem.DTOs.DriverDto
{
    public class DriverDto
    {
        public int Id{ get; set; }
        public string DivId{ get; set; }
        public int ParkId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime Dob{ get; set; }
        public string Address { get; set; }
        public string PhoneNumber{ get; set; }
        public string ParkName{ get; set; }
        public string CarReg{ get; set; }
        public string CarName{ get; set; }
        public int NoofSeat { get; set; }
        public virtual IList<Motor> Motors { get; set; } = new List<Motor>();
    }

    public class DriverRequestModel
    {
        public string DivId{ get; set; }
        public int ParkId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime Dob{ get; set; }
        //public string ParkName{ get; set; }
        //public string CarReg{ get; set; }
        //public string CarName{ get; set; }
        //public int NoofSeat { get; set; }
        public string Address { get; set; }
        public string PhoneNumber{ get; set; }
        public virtual IList<Motor> Motors { get; set; } = new List<Motor>();
    }

    public class DriverResponseModel:BaseResponseModel//, IEnumerable
    {
        public DriverDto Data { get; set; }
        /*public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }*/
    }
    public class DriversResponseModel:BaseResponseModel
    {
        public IList<DriverDto> Data { get; set; } = new List<DriverDto>();
    }
}