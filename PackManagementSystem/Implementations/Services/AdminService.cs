using System.Collections.Generic;
using System.Linq;
using PackManagementSystem.DTOs.AdminDto;
using PackManagementSystem.Entities;
using PackManagementSystem.Implementations.Repositories;
using PackManagementSystem.Interfaces.Repositories;
using PackManagementSystem.Interfaces.Services;

namespace PackManagementSystem.Implementations.Services
{
    public class AdminService:IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public AdminResponseModel GetAdmin(int id)
        {
            var admin = _adminRepository.GetAdmin(id);
            if (admin == null)
            {
                return new AdminResponseModel {Status = false, Message = "Not Found"};
            }

            return new AdminResponseModel
            {
                Status = true,
                Data = new AdminDto
                {
                    Id = admin.Id, Surname = $"{admin.Firstname} {admin.Lastname}", Tel = admin.PhoneNumber
                }
            };
        }

        public AdminResponseModel CreateAdmin(AdminRequestModel admin)
        {
            var newAdmin = new Admin()
            {
                Firstname = admin.FirstName,Lastname = admin.Surname,PhoneNumber = admin.Tel,Email = admin.Email,
                Password = admin.Password
            };
            var ad = _adminRepository.CreateAdmin(newAdmin);
            if (ad != null)
            {
                return new AdminResponseModel {Status = true, Message = "Admin Successfully Created"};
            }

            return new AdminResponseModel() {Status = false, Message = "Admin not Created"};
        }

        public bool DeleteAdmin(int id)
        {
            var admin = _adminRepository.GetAdmin(id);
            if (admin != null)
            {
                _adminRepository.DeleteAdmin(admin);
                return true;
            }

            return false;
        }

        public Admin UpdateAdmin(AdminRequestModel admin, int id)
        {
            var ad = _adminRepository.GAdmin(id);
            //if (ad == null) return new AdminResponseModel {Status = false, Message = " Failed to Update"};
            ad.Firstname = admin.FirstName;
            ad.Lastname = admin.Surname;
            ad.Email = admin.Email;
            ad.PhoneNumber = admin.Tel;
            ad.Password = admin.Password;
            var updateAdmin = _adminRepository.UpdateAdmin(ad);
            return updateAdmin;
        }

        public AdminsResponseModel GetAdmins()
        {
            var admin = _adminRepository.GetAdmins().Select(admin =>new AdminDto()
            {
                Id = admin.Id, Surname = $"{admin.Firstname} {admin.Lastname}", Tel = admin.PhoneNumber
            }).ToList();
            return new AdminsResponseModel(){Status = true,Data = admin};
        }

        public AdminResponseModel AdminLogin(AdminRequestModel passwd, AdminRequestModel mail)
        {
            var admin = new Admin() {Email = mail.Email, Password = passwd.Password};
            var email = _adminRepository.AdminLogin(admin.Password, admin.Email);
            if (email==null)
            {
                return new AdminResponseModel() {Status = false, Message = "Wrong username or Password"};
            }

            return new AdminResponseModel() {Status = true, Data = new AdminDto(){Id =email.Id,  Email = email.Email, FirstName = email.Firstname, Password = email.Password}};
        }

        public Admin GAdmin(int id)
        {
            var admin = _adminRepository.GAdmin(id);
            return admin;
        }
    }
}