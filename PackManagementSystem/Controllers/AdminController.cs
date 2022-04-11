using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PackManagementSystem.DTOs.AdminDto;
using PackManagementSystem.DTOs.ParkDto;
using PackManagementSystem.DTOs.StaffDto;
using PackManagementSystem.Entities;
using PackManagementSystem.Interfaces.Services;

namespace PackManagementSystem.Controllers
{
    public class AdminController:Controller
    {
        private readonly IAdminService _adminServices;
        private readonly IParkService _parkService;
        private readonly IStaffService _staffService;

        public AdminController(IAdminService adminService, IParkService parkService, IStaffService staffService)
        {
            _adminServices = adminService;
            _parkService = parkService;
            _staffService = staffService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(AdminRequestModel psword, AdminRequestModel mail)
        {
            
            var admin = _adminServices.AdminLogin(psword, mail);
            if (admin.Status)
            {
                HttpContext.Session.SetString("email",admin.Data.Email);
                HttpContext.Session.SetString("firstname",admin.Data.FirstName);
                HttpContext.Session.SetString("password",admin.Data.Password);
                HttpContext.Session.SetInt32("id",admin.Data.Id);
                return RedirectToAction("AdminMenu");
            }

            ViewBag.Message = admin.Message;
            return View();

        }

        public IActionResult SignUp()
        {
            if (HttpContext.Session.GetString("password") == null && HttpContext.Session.GetString("email") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(AdminRequestModel adminRequestModel)
        {
            var admin = _adminServices.CreateAdmin(adminRequestModel);
            return RedirectToAction("AdminMenu");
        }

        public IActionResult DeleteAdmin(int id, AdminDto ids)
        {
            if (HttpContext.Session.GetString("password") == null && HttpContext.Session.GetString("email") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var admin =_adminServices.GetAdmin(id);
            if (admin==null || admin.Data.Id==1)
            {
                return NotFound();
            }
            return View("DeleteAdmin");
            
        }
        [HttpPost,  ActionName("DeleteAdmin")]
        public IActionResult DeleteAdmin(int id)
        {
            var admin =_adminServices.DeleteAdmin(id);
            return RedirectToAction("AdminMenu");
        }

        public IActionResult AdminMenu()
        {
            if (HttpContext.Session.GetString("password") == null && HttpContext.Session.GetString("email") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else if(HttpContext.Session.GetString("email")=="oladejimujeeb@yahoo.com")
            {
                var admins = _adminServices.GetAdmins();
                ViewBag.Message = admins.Message;
                ViewBag.SuperAdmin = "NURTW CHAIRMAN";
                return View(admins.Data);
            }
            else
            {
                int id = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
                var adm = _adminServices.GetAdmin(id);
                
                var subAdmin = new AdminsResponseModel { Data=new[] {adm.Data} };
                return View(subAdmin.Data);
            }
        }

        public IActionResult UpdateAdmin(int id)
        {
            if (HttpContext.Session.GetString("password") == null && HttpContext.Session.GetString("email") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var admin = _adminServices.GAdmin(id);
            
            if (admin == null)
            {
                return NotFound("This Admin Cannot be Deleted");
            }
            return View(admin);
        }
        [HttpPost]
        public IActionResult UpdateAdmin(AdminRequestModel adminDto, int id)
        {
            var admin = _adminServices.UpdateAdmin(adminDto, id);
            return RedirectToAction("AdminMenu");
        }
//Park controller starts here
        public IActionResult AddPark()
        {
            if (HttpContext.Session.GetString("password") == null && HttpContext.Session.GetString("email") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }
        [HttpPost]
        public IActionResult AddPark(ParkRequestModel park)
        {
            var addPark = _parkService.CreatePark(park);
            return RedirectToAction("AdminMenu");
        }
        public IActionResult AllParks()
        {
            if (HttpContext.Session.GetString("password") == null && HttpContext.Session.GetString("email") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var park = _parkService.GetAllPark();
            return View(park.Data);
        }
        
        public IActionResult DeletePark(int id)
        {
            var pk = _parkService.GetPark(id);
            if (pk==null)
            {
                return View(pk.Message);
            }

            return View("DeletePark");

        }
        [HttpPost, ActionName("DeletePark")]
        public IActionResult DeletePark(int id, Park pk)
        {
            var park = _parkService.DeletePark(id);
            if (park)
            {
                return RedirectToAction("AdminMenu");
            }

            return NotFound();
        }

        public IActionResult UpdatePark(int id)
        {
            if (HttpContext.Session.GetString("password") == null && HttpContext.Session.GetString("email") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var update = _parkService.GetPark(id);
            if (update == null)
            {
                return View(update.Message);
            }

            return View(update);
        }
        [HttpPost]
        public IActionResult UpdatePark(ParkRequestModel request, int id)
        {
            var park = _parkService.Update(request, id);
            return RedirectToAction("AllParks");
        }
//Staff controller starts here
        public IActionResult AddStaff()
        {
            if (HttpContext.Session.GetString("password") == null && HttpContext.Session.GetString("email") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var park = _parkService.GetAllPark();
            
            ViewData["Parks"] = new SelectList(park.Data, "Id", "ParkName");
            return View();
        }
        [HttpPost]
        public IActionResult AddStaff(StaffRequestModel staff)
        {
            var sta = _staffService.CreateStaff(staff);
            return RedirectToAction("AllStaff");
        }

        public IActionResult AllStaff()
        {
            if (HttpContext.Session.GetString("password") == null && HttpContext.Session.GetString("email") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var staff = _staffService.GetAllStaff();
            return View(staff.Data);
        }
        public IActionResult DeleteStaff(int id, StaffDto ids)
        {
            if (HttpContext.Session.GetString("password") == null && HttpContext.Session.GetString("email") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var staff = _staffService.GetStaff(id);
            if (staff==null)
            {
                return NotFound();
            }
            return View("DeleteStaff");
            
        }
        [HttpPost,  ActionName("DeleteStaff")]
        public IActionResult DeleteStaff(int id)
        {
            var admin =_staffService.DeleteStaff(id);
            if (admin)
            {
                return RedirectToAction("AdminMenu");
            }

            return NotFound();
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}