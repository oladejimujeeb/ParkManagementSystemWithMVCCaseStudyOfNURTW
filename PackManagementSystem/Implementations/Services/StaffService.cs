using System;
using System.Linq;
using PackManagementSystem.DTOs.StaffDto;
using PackManagementSystem.Entities;
using PackManagementSystem.Interfaces.Repositories;
using PackManagementSystem.Interfaces.Services;

namespace PackManagementSystem.Implementations.Services
{
    public class StaffService:IStaffService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public StaffResponseModel GetStaff(int id)
        {
            var staff = _staffRepository.GetStaff(id);
            
            if (staff == null)
            {
                return new StaffResponseModel() {Message = "Not found", Status = false};
            }

            return new StaffResponseModel() {Status = true,Data = new StaffDto
            {
                Firstname = staff.Firstname,Surname = staff.Lastname, Address = staff.Address,Email = staff.Email,
                Dob = staff.Dob, PhoneNumber = staff.PhoneNumber,PackId = staff.PackId,StaffId = staff.RegNum
            }};
        }

        public StaffsResponseModel GetAllStaff()
        {
            var staf = _staffRepository.GetAllStaff().Select(staff => new StaffDto
            { 
                Id = staff.Id,
                Firstname = staff.Firstname,Surname = staff.Lastname, Address = staff.Address,Email = staff.Email,
                Dob = staff.Dob, PhoneNumber = staff.PhoneNumber,PackId = staff.PackId,StaffId = staff.RegNum
            }).ToList();
            return new StaffsResponseModel() {Data = staf};
        }

        public StaffResponseModel CreateStaff(StaffRequestModel staff)
        {
            string staffId = $"Sta/{Guid.NewGuid().ToString().Substring(0, 3)}";
            var sta = new Staff()
            {
                Firstname = staff.Firstname,Lastname = staff.Surname, Address = staff.Address,Email = staff.Email,
                Dob = staff.Dob, PhoneNumber = staff.PhoneNumber,PackId = staff.PackId,RegNum = staffId
            };
            var addStaff = _staffRepository.CreateStaff(sta);
            return new StaffResponseModel() {Message = "Staff Successfully Added", Status = true};
        }

        public bool DeleteStaff(int id)
        {
            var sta = _staffRepository.GetStaff(id);
            if (sta == null)
            {
                return false;
            }

            var staff = _staffRepository.DeleteStaff(sta);
            return true;
        }

        public StaffResponseModel Update(StaffRequestModel staff, int id)
        {
            var sta = _staffRepository.GetStaff(id);
            if (sta == null)
            {
                return new StaffResponseModel() {Status = false, Message = "Failed"};
            }

            sta.Firstname = staff.Firstname;
            sta.Lastname = staff.Surname;
            sta.Address = staff.Address;
            sta.Email = staff.Email;
            var staf = _staffRepository.UpdateStaff(sta);
            return new StaffResponseModel() {Message = "Updated Successfully"};
        }

        public StaffResponseModel StaffLogin( StaffRequestModel staffId)
        {
            //string mail = email.Email;
            string regId = staffId.StaffId;
            var login = _staffRepository.StaffLogin(regId);
            if (login == null)
            {
                return new StaffResponseModel()
                {
                    Status = false,Message = "Invalid username or password"
                };
            }

            return new StaffResponseModel() {Status = true, Data = new StaffDto()
            {
                Firstname = login.Firstname,Id = login.Id, Email = login.Email,StaffId = login.RegNum
            }};
        }
    }
}