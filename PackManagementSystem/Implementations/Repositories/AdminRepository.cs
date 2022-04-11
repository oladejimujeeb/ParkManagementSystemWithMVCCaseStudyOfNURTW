using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PackManagementSystem.Context;
using PackManagementSystem.DTOs.AdminDto;
using PackManagementSystem.Entities;
using PackManagementSystem.Interfaces.Repositories;

namespace PackManagementSystem.Implementations.Repositories
{
    public class AdminRepository:IAdminRepository
    {
        private readonly ApplicationContext _context;

        public AdminRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Admin GetAdmin(int id)
        {
            var admin = _context.Admins.Find(id);
            return admin;
        }

        public Admin GAdmin(int id)
        {
            var admin = _context.Admins.Find(id);
            return admin;
        }

        public Admin CreateAdmin(Admin admin)
        {
            if (_context.Admins.Count() < 3)
            {
                _context.Admins.Add(admin);
                _context.SaveChanges();
            }
            return admin;
        }

        public bool DeleteAdmin(Admin admin)
        {
            _context.Admins.Remove(admin);
            _context.SaveChanges();
            return true;
        }

        public Admin UpdateAdmin(Admin admin)
        {
            _context.Admins.Update(admin);
            _context.SaveChanges();
            return admin;
        }

        public IList<Admin> GetAdmins()
        {
            var admins = _context.Admins.ToList();
            return admins;
        }

        public Admin AdminLogin(string password, string email)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Password==password && a.Email==email);
            return admin;
        }
    }
}