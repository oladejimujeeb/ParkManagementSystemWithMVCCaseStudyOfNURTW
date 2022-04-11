using System.Collections.Generic;
using PackManagementSystem.DTOs.StaffDto;
using PackManagementSystem.Entities;

namespace PackManagementSystem.Interfaces.Repositories
{
    public interface IStaffRepository
    {
        Staff CreateStaff(Staff staff);
        IList<Staff> GetAllStaff();
        bool DeleteStaff(Staff staff);
        Staff UpdateStaff(Staff staff);
        Staff GetStaff(int id);
        Staff StaffLogin(string staffId);
    }
}