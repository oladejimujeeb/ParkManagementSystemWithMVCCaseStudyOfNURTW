using System.Collections;
using System.Collections.Generic;
using PackManagementSystem.Entities;

namespace PackManagementSystem.Interfaces.Repositories
{
    public interface IAdminRepository
    {
        Admin GetAdmin(int id);
        Admin GAdmin(int id);
        Admin CreateAdmin(Admin admin);
        bool DeleteAdmin(Admin admin);
        Admin UpdateAdmin(Admin admin);
        IList<Admin> GetAdmins();
        Admin AdminLogin(string password, string email);
    }
}