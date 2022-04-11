using PackManagementSystem.DTOs.StaffDto;

namespace PackManagementSystem.Interfaces.Services
{
    public interface IStaffService
    {
        StaffResponseModel GetStaff(int id);
        StaffsResponseModel GetAllStaff();
        StaffResponseModel CreateStaff(StaffRequestModel staff);
        bool DeleteStaff(int id);
        StaffResponseModel Update(StaffRequestModel staff, int id);
        StaffResponseModel StaffLogin(StaffRequestModel staffId);

    }
}