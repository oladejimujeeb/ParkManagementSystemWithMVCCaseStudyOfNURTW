using System.Linq;
using PackManagementSystem.DTOs.ParkDto;
using PackManagementSystem.Entities;
using PackManagementSystem.Interfaces.Repositories;
using PackManagementSystem.Interfaces.Services;

namespace PackManagementSystem.Implementations.Services
{
    public class ParkService:IParkService
    {
        private readonly IParkRepository _parkRepository;

        public ParkService(IParkRepository parkRepository)
        {
            _parkRepository = parkRepository;
        }
        public ParkResponseModel GetPark(int id)
        {
            var park = _parkRepository.GetPark(id);
            if (park==null)
            {
                return new ParkResponseModel() {Message = "Park not found", Status = false};
            }

            return new ParkResponseModel
            {
                Status = true,
                Data = new ParkDto
                {
                    ParkName = park.Name,
                    ParkPrice = park.Price
                }
            };
        }

        public ParksResponseModel GetAllPark()
        {
            var park = _parkRepository.GetAllParks().Select(park =>new ParkDto
                {Id = park.Id, ParkName = park.Name, ParkPrice = park.Price}).ToList();
            return new ParksResponseModel {Status = true, Data = park};
        }

        public ParkResponseModel CreatePark(ParkRequestModel park)
        {
            var newPark = new Park{Name = park.ParkName, Price = park.ParkPrice};
            var addPark = _parkRepository.CreatePark(newPark);
            if (addPark == null)
            {
                return new ParkResponseModel {Status = false, Message = "Park not Add"};
            }

            return new ParkResponseModel
            {
                Data = new ParkDto{ParkName = addPark.Name, ParkPrice = addPark.Price}
            };
        }

        public bool DeletePark(int id)
        {
            var park = _parkRepository.GetPark(id);
            if (park == null)
            {
                return false;
            }

            var pk = _parkRepository.DeletePark(park);
            return pk;
        }

        public ParkResponseModel Update(ParkRequestModel park, int id)
        {
            var pk = _parkRepository.GetPark(id);
            if (pk == null)
            {
                return new ParkResponseModel {Status = false, Message = "Error, Update failed"};
            }

            pk.Name = park.ParkName;
            pk.Price = park.ParkPrice;
            var updatePark = _parkRepository.UpdatePark(pk);
            return new ParkResponseModel() {Status = true};
        }
    }
}