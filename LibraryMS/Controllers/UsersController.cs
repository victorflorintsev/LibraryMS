using System;
using System.Collections.Generic;
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
            return View(test);
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
            Users outUser = new Users();
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
    }
}
