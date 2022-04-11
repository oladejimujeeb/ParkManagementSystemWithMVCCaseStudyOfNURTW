using System.Collections.Generic;
using System.Linq;
using PackManagementSystem.Context;
using PackManagementSystem.DTOs.StaffDto;
using PackManagementSystem.Entities;
using PackManagementSystem.Interfaces.Repositories;

namespace PackManagementSystem.Implementations.Repositories
{
    public class StaffRepository:IStaffRepository
    {
        private readonly ApplicationContext _context;

        public StaffRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Staff CreateStaff(Staff staff)
        {
            _context.Staffs.Add(staff);
            _context.SaveChanges();
            return staff;
        }

        public IList<Staff> GetAllStaff()
        {
            return _context.Staffs.ToList();
        }

        public bool DeleteStaff(Staff staff)
        {
            _context.Staffs.Remove(staff);
            _context.SaveChanges();
            return true;
        }

        public Staff UpdateStaff(Staff staff)
        {
             _context.Staffs.Update(staff);
             _context.SaveChanges();
             return staff;
        }

        public Staff GetStaff(int id)
        {
            return _context.Staffs.Find(id);
        }

        public Staff StaffLogin(string staffId )
        {
            var login = _context.Staffs.FirstOrDefault(x =>  x.RegNum == staffId );

            return login;
        }
    }
}