﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using LibraryMS.Views.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryMS.Controllers
{
    public class UsersController : Controller
    {
        // GET: /<controller>/
      
        private IUsers _context;

        public UsersController(IUsers context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Users> test = _context.GetAll();
            UserViewModel outmodel = new UserViewModel();
            outmodel.User = test;
            return View(outmodel);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult UserProfile()
        {
            string username = User.Identity.Name;

            Users users = _context.GetById(username);
            return View(users);
        }

        public IActionResult AccountInfo()
        {
            string username = User.Identity.Name;
            Users user = _context.GetById(username);
            return View(user);
        }

        public IActionResult CheckoutHistory()
        {
            string username = User.Identity.Name;
            IEnumerable<Borrow> borrowedMedia = _context.GetBorrowedMediaById(username);
            Users outUser = _context.GetById(username);
            outUser.Borrow = new List<Borrow>(borrowedMedia);
            return View(outUser);
        }


        [HttpGet]
        public IActionResult EditProfile()
        {
            Users userToEdit = _context.GetById(User.Identity.Name);
            return View(userToEdit);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditProfile(Users user)
        {
            _context.Update(user);

            return RedirectToAction("UserProfile");

        }

        public IActionResult Holds()
        {
            string username = User.Identity.Name;
            IEnumerable<IsWaitlistedBy> waitlistedMedia = _context.GetHeldMediaById(username);
            Users outUser = _context.GetById(username);
            outUser.IsWaitlistedBy = new List<IsWaitlistedBy>(waitlistedMedia);
            return View(outUser);
        }

        public IActionResult Fines()
        {
            string username = User.Identity.Name;
            IEnumerable<Fine> fines = _context.GetFinesById(username);
            Users outUser = _context.GetById(username);
            outUser.Fine = new List<Fine>(fines);
            return View(outUser);
        }
        public IActionResult PayFine(decimal amount)
        {
            string username = User.Identity.Name;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=den1.mssql4.gear.host;Database=cosc3380;Uid=cosc3380;Pwd=vfegaf$;";
            conn.Open();

            string payfine = "UPDATE LIBDB.FINE set Amount=Amount-"+ amount + " where UserName='" + username + "'";
            SqlCommand update_fine = new SqlCommand(payfine, conn);
            update_fine.ExecuteNonQuery();

            conn.Close();
            return View();
        }

        public IActionResult ChangeType(string id, int changeTo)
        {
            _context.changeUserType(id, changeTo);
            return View();
        }

        public IActionResult NewCustomerCreationReport(DateTime fromTime, DateTime toTime)
        {
            var records = _context.NewCustomerCreationReport(fromTime, toTime);
            ViewBag.fromTime = fromTime;
            ViewBag.toTime = toTime;
            return View(records);
        }


    }
}
