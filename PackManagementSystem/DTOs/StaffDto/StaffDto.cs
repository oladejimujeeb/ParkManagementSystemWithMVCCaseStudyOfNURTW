using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace PackManagementSystem.DTOs.StaffDto
{
    public class StaffDto
    {
        public int Id{ get; set; }
        public string StaffId{ get; set; }
        public int PackId{ get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime Dob{ get; set; }
        public string Address { get; set; }
        public string PhoneNumber{ get; set; }
    }

    public class StaffRequestModel
    {
        public string StaffId{ get; set; }
        public int PackId{ get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime Dob{ get; set; }
        public string Address { get; set; }
        public string PhoneNumber{ get; set; }
    }

    public class StaffResponseModel:BaseResponseModel
    {
        public  StaffDto Data { get; set; }
    }

    public class StaffsResponseModel:BaseResponseModel
    {
        public IList<StaffDto> Data { get; set; } = new List<StaffDto>();
    }
}