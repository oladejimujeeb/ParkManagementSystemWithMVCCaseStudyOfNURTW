using System.Collections.Generic;
using PackManagementSystem.Entities;

namespace PackManagementSystem.Interfaces.Repositories
{
    public interface IParkRepository
    {
        Park CreatePark(Park park);
        IList<Park> GetAllParks();
        bool DeletePark(Park park);
        Park UpdatePark(Park park);
        Park GetPark(int id);
        //Park GetParkByMotor(int motorId);
    }
}