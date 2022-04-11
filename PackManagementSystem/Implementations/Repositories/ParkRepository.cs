using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PackManagementSystem.Context;
using PackManagementSystem.Entities;
using PackManagementSystem.Interfaces.Repositories;

namespace PackManagementSystem.Implementations.Repositories
{
    public class ParkRepository:IParkRepository
    {
        private readonly ApplicationContext _context;

        public ParkRepository(ApplicationContext context)
        {
            _context = context;
        }
        
        public Park CreatePark(Park park)
        {
            _context.Parks.Add(park);
            _context.SaveChanges();
            return park;
        }

        public IList<Park> GetAllParks()
        {
            var parks = _context.Parks.ToList();
            return parks;
        }

        public bool DeletePark(Park park)
        {
            _context.Parks.Remove(park);
            _context.SaveChanges();
            return true;
        }

        public Park UpdatePark(Park park)
        {
            _context.Parks.Update(park);
            _context.SaveChanges();
            return park;
        }

        public Park GetPark(int id)
        {
            var park = _context.Parks.Find(id);
            return park;
        }
        
    }
}