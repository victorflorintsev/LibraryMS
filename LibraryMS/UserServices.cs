using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            /*List<Users> outList = new List<Users>();
            IEnumerable<Users> a = _context.Users;
            foreach (Users u in _context.Users()) {
                outList.Add(u);
            }*/
            
            //return outList;
            List<Users> outList = new List<Users>();
            //outList.Add(_context.Users.First());
            foreach (Users u in _context.Users)
            {
                outList.Add(u);
            }

            return outList;
        }
    }
}



