using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using LibraryMS.Models;

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
            foreach (Users u in _context.Users)
            {
                outList.Add(u);
            }

            return outList;
        }

<<<<<<< HEAD
        public Users GetById(string username)
        {
            return _context.Users.FirstOrDefault(asset => asset.UserName == username);

        }

        public List<Fine> GetFinesById(string username)
        {
            List<Fine> outList = new List<Fine>();
            foreach (Fine f in _context.Fine)
            {
                outList.Add(f);
            }

            return outList;
=======
>>>>>>> 17163e48a69fa188ec7ca8afa1ec864595346d5f
        }
    }
}



