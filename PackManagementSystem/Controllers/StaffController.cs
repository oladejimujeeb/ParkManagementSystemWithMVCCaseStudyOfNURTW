using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackManagementSystem.DTOs.PaymentDto;
using PackManagementSystem.DTOs.StaffDto;
using PackManagementSystem.Interfaces.Services;

namespace PackManagementSystem.Controllers
{
    public class StaffController:Controller
    {
        private readonly IStaffService _staffService;
        private readonly IDriverService _driverService;
        private readonly IPaymentService _paymentService;

        public StaffController(IStaffService staffService, IDriverService driverService, IPaymentService paymentService)
        {
            _staffService = staffService;
            _driverService = driverService;
            _paymentService = paymentService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(StaffRequestModel staId )
        {
            var login = _staffService.StaffLogin(staId);
            if (login.Status)
            {
                HttpContext.Session.SetString("email",login.Data.Email);
                HttpContext.Session.SetString("firstname",login.Data.Firstname);
                HttpContext.Session.SetInt32("id", login.Data.Id);
                return RedirectToAction("StaffMenu");
            }

            ViewBag.Message=login.Message;
            return View();

        }
        public IActionResult StaffMenu()
        {
            if (HttpContext.Session.GetString("id") == null && HttpContext.Session.GetString("firstname") == null)
            {
                return RedirectToAction("Login", "Staff");
            }
            var id = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            var staff = _staffService.GetStaff(id);
            var staffDetails = $"{staff.Data.Firstname} {staff.Data.Surname   },  Staff Id: {staff.Data.StaffId}, Email: {staff.Data.Email} ";
            ViewBag.staffInfo = staffDetails;
            return View();
        }

        public IActionResult AllDrivers()
        {
            if (HttpContext.Session.GetString("id") == null && HttpContext.Session.GetString("firstname") == null)
            {
                return RedirectToAction("Login", "Staff");
            }
            var drivers = _driverService.GetAllDrivers();
            return View(drivers.Data);
        }

        public IActionResult DeleteDriver(int id)
        {
            if (HttpContext.Session.GetString("id") == null && HttpContext.Session.GetString("firstname") == null)
            {
                return RedirectToAction("Login", "Staff");
            }
            var deleteDriver = _driverService.DeleteDriver(id);
            if (deleteDriver)
            {
                return RedirectToAction("StaffMenu");
            }

            return NotFound();
        }

        public IActionResult CheckPaymentByDate(PaymentRequestModel date)
        {
            if (HttpContext.Session.GetString("id") == null && HttpContext.Session.GetString("firstname") == null)
            {
                return RedirectToAction("Login", "Staff");
            }
            var paymentDate = _paymentService.SearchPayment(date.PaymentDate);
            if (paymentDate.Status)
            {
                return View(paymentDate.Data);
            }

            ViewBag.PaymentMSG = paymentDate.Message;
            return View();
        }

        public IActionResult CheckPaymentByEmail(PaymentRequestModel model)
        {
            if (HttpContext.Session.GetString("id") == null && HttpContext.Session.GetString("firstname") == null)
            {
                return RedirectToAction("Login", "Staff");
            }

            var payment = _paymentService.SearchPaymentByPhoneNo(model.Email);
            if (payment.Status)
            {
                return View(payment.Data);
            }
            ViewBag.PaymentMSG = payment.Message;
            return View();
        }
    }
}