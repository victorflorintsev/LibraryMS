using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using LibraryMS.Models;
using Microsoft.AspNetCore.Mvc.Razor;

namespace LibraryMS
{
    public class UserServices : IUsers
    {
        private cosc3380Context _context;
        public UserServices(cosc3380Context context)
        {
            _context = context;
        }

        public void Add(Users newUser)
        {
            _context.Add(newUser);
            _context.SaveChanges();
        }

        public List<Users> GetAll()
        {
            List<Users> outList = new List<Users>();
            foreach (Users u in _context.Users) {
                outList.Add(u);
            }

            return outList;
        }

        public bool isEmployee(string username)
        {
            if (_context.Users.FirstOrDefault(asset => asset.UserName == username).UserType == 0)
            {
                return true;
            }
            return false;
        }
    }
}



