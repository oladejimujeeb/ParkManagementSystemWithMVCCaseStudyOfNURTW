using System;
using System.Collections.Generic;
using System.Net.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PackManagementSystem.DTOs.DriverDto;
using PackManagementSystem.DTOs.MotorDto;
using PackManagementSystem.DTOs.PaymentDto;
using PackManagementSystem.Interfaces.Services;

namespace PackManagementSystem.Controllers
{
    public class DriverController:Controller
    {
        private readonly IDriverService _driverService;
        private readonly IParkService _parkService;
        private readonly IMotorService _motorService;
        private readonly IPaymentService _paymentService;

        public DriverController(IDriverService driverService, IParkService parkService, IMotorService motorService, IPaymentService paymentService)
        {
            _driverService = driverService;
            _parkService = parkService;
            _motorService = motorService;
            _paymentService = paymentService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(DriverRequestModel mail, DriverRequestModel driverId)
        {
            var login = _driverService.DriverLogin(mail, driverId);
            if (login.Status)
            {
                HttpContext.Session.SetString("email",login.Data.Email);
                HttpContext.Session.SetString("firstname",login.Data.Firstname);
                HttpContext.Session.SetString("DriverId",login.Data.DivId);
                HttpContext.Session.SetInt32("id", login.Data.Id);
                return RedirectToAction("DriverIndex");
            }

            ViewBag.Message = login.Message;
            return View();
        }
        
        public IActionResult DriverIndex()
        {
            if (HttpContext.Session.GetString("firstname") == null && HttpContext.Session.GetString("email")==null)
            {
                return RedirectToAction("Login", "Driver");
            }
            else
            {
                var id = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
                var div = _driverService.GetDriver(id);
                var driverDetail =
                    $"{ div.Data.Firstname + " " + div.Data.Surname} Phone number:{div.Data.PhoneNumber} Email:{div.Data.Email}";
                ViewBag.Div = driverDetail;
                var divInfo = _driverService.GetDriverByCar(id);
            
                if (divInfo==null)
                {
                    return NoContent();
                }
            
                return View(divInfo);
            }
        }

        public IActionResult SignUp()
        {
            var park = _parkService.GetAllPark();
            ViewData["AllParks"] = new SelectList(park.Data, "Id", "ParkName");
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(DriverRequestModel requestModel)
        {
            var driver = _driverService.CreateDriver(requestModel);
            if (driver.Status==false)
            {
                ViewBag.AddDriver = driver.Message;
                return View();
            }

            return RedirectToAction("Login");
        }
        
        public IActionResult RegisterCar()
        {
            if (HttpContext.Session.GetString("firstname") == null && HttpContext.Session.GetString("email")==null)
            {
                return RedirectToAction("Login", "Driver");
            }
            var park = _parkService.GetAllPark();
            ViewData["Parks"] = new SelectList(park.Data, "Id", "ParkName");
            return View();
        }
        [HttpPost]
        public IActionResult RegisterCar(MotorRequestModel requestModel)
        {
            var id = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            var addCar = _motorService.CreateMotor(requestModel, id);
            return RedirectToAction("DriverIndex");
        }

        public IActionResult UpdateDriver()
        {
            if (HttpContext.Session.GetString("firstname") == null && HttpContext.Session.GetString("email")==null)
            {
                return RedirectToAction("Login", "Driver");
            }
            var id = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            var get = _driverService.GetDriver(id);
            var park = _parkService.GetAllPark();
            ViewData["AllParks"] = new SelectList(park.Data, "Id", "ParkName");
            if (get.Data == null)
            {
                ViewBag.UpdateMsg = "Cannot be updated";
                return View();
            }
            return View(get);
        }
        [HttpPost]
        public IActionResult UpdateDriver(DriverRequestModel driver)
        {
            var id = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
            var upDate = _driverService.UpdateDriver(driver, id);
            return RedirectToAction("DriverIndex");
        }

        public IActionResult MakePayment()
        {
            if (HttpContext.Session.GetString("firstname") == null && HttpContext.Session.GetString("email")==null)
            {
                return RedirectToAction("Login", "Driver");
            }
            return View();
        }
        
        [HttpPost]
        public IActionResult MakePayment(PaymentRequestModel requestModel, int id)
        {
            var pay = _paymentService.MakePayment(requestModel, id);
            if (pay.Status)
            {
                ViewBag.PaymentConfirmed = $"Paid, Amount: #{pay.Data.Amount}, Expired on:{pay.Data.ExpiryDate}";
                return View();
                
            }
            else
            {
                ViewBag.PayFailed = "Your Payment fail";
                return View();
            }
        }

        public IActionResult CheckPaymentHistory()
        {
            if (HttpContext.Session.GetString("firstname") == null && HttpContext.Session.GetString("email")==null)
            {
                return RedirectToAction("Login", "Driver");
            }

            var divId = HttpContext.Session.GetString("DriverId");
            var paymentHistory = _paymentService.SearchPaymentByDriver(divId);
            if (paymentHistory.Status)
            {
                return View(paymentHistory.Data);
            }

            ViewBag.Nopayment = paymentHistory.Message;
            return View();

        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        
    }
}