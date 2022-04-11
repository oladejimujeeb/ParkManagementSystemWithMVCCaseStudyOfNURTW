using PackManagementSystem.DTOs.ParkDto;

namespace PackManagementSystem.Interfaces.Services
{
    public interface IParkService
    {
        ParkResponseModel GetPark(int id);
        ParksResponseModel GetAllPark();
        ParkResponseModel CreatePark(ParkRequestModel park);
        bool DeletePark(int id);
        ParkResponseModel Update(ParkRequestModel park, int id);

    }
}