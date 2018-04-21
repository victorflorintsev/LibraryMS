using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryMS.Controllers
{
    public class UsersController : Controller
    {
        // GET: /<controller>/
        private readonly IUsers _context;
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
    }
}
