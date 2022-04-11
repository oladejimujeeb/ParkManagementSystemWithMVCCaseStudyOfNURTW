using System.Collections.Generic;
using PackManagementSystem.DTOs.AdminDto;
using PackManagementSystem.Entities;

namespace PackManagementSystem.Interfaces.Services
{
    public interface IAdminService
    {
        AdminResponseModel GetAdmin(int id);
        AdminResponseModel CreateAdmin(AdminRequestModel admin);
        bool DeleteAdmin(int id);
        Admin UpdateAdmin(AdminRequestModel admin, int id);
        AdminsResponseModel GetAdmins();
        AdminResponseModel AdminLogin(AdminRequestModel password, AdminRequestModel email);
        Admin GAdmin(int id);
    }
}