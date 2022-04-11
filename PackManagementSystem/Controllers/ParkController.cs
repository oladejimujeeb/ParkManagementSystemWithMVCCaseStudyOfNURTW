using Microsoft.AspNetCore.Mvc;
using PackManagementSystem.DTOs.ParkDto;
using PackManagementSystem.Interfaces.Services;

namespace PackManagementSystem.Controllers
{
    public class ParkController:Controller
    {
        private readonly IParkService _parkService;

        public ParkController(IParkService parkService)
        {
            _parkService = parkService;
        }

        
    }
}